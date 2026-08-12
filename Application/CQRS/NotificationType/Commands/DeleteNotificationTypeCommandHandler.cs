using Application.Abstractions;

namespace Application.CQRS.NotificationType.Commands;

public class DeleteNotificationTypeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteNotificationTypeCommandHandler : ICommandHandler<DeleteNotificationTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificationTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteNotificationTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationTypeNotFound);

        _unitOfWork.NotificationTypeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationTypeNotDeleted);
    }
}