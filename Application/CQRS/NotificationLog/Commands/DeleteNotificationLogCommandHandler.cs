using Application.Abstractions;

namespace Application.CQRS.NotificationLog.Commands;

public class DeleteNotificationLogCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteNotificationLogCommandHandler : ICommandHandler<DeleteNotificationLogCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNotificationLogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteNotificationLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationLogRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationLogNotFound);

        _unitOfWork.NotificationLogRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationLogNotDeleted);
    }
}