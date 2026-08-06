using Application.Abstractions;

namespace Application.CQRS.NotificationState.Commands;

public class DeleteNotificationStateCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteNotificationStateCommandHandler : ICommandHandler<DeleteNotificationStateCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificationStateCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteNotificationStateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationStateRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationStateNotFound);

        _unitOfWork.NotificationStateRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationStateNotDeleted);
    }
}