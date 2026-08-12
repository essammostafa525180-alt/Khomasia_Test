using Application.Abstractions;

namespace Application.CQRS.NotificationLog.Commands;

public class UpdateNotificationLogCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? TemplateId { get; set; }
        public int? LoyaltyLevelId { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateNotificationLogCommandHandler : ICommandHandler<UpdateNotificationLogCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateNotificationLogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateNotificationLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.NotificationLogRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.NotificationLogNotFound);

        entity.Update(request.CustomerId, request.TemplateId, request.LoyaltyLevelId, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.NotificationLogNotUpdated);
    }
}