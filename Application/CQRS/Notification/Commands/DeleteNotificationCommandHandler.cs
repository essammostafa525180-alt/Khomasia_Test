using Application.Abstractions;

namespace Application.CQRS.Notification.Commands;

public class DeleteNotificationCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteNotificationCommandHandler : ICommandHandler<DeleteNotificationCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationNotFound);

        _unitOfWork.NotificationRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationNotDeleted);
    }
}