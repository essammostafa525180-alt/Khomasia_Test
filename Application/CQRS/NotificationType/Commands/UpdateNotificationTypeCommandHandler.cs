using Application.Abstractions;

namespace Application.CQRS.NotificationType.Commands;

public class UpdateNotificationTypeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? NotificationTypeEn { get; set; }
        public string? NotificationTypeAr { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateNotificationTypeCommandHandler : ICommandHandler<UpdateNotificationTypeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNotificationTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateNotificationTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationTypeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationTypeNotFound);

        entity.Update(request.NotificationTypeEn, request.NotificationTypeAr, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationTypeNotUpdated);
    }
}