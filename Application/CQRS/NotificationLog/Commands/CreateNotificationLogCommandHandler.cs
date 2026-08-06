using Application.Abstractions;

namespace Application.CQRS.NotificationLog.Commands;

public class CreateNotificationLogCommand : ICommand<Result<int>>
{
        public int? CustomerId { get; set; }
        public int? TemplateId { get; set; }
        public int? LoyaltyLevelId { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateNotificationLogCommandHandler : ICommandHandler<CreateNotificationLogCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNotificationLogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateNotificationLogCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.NotificationAggregate.NotificationLog.Create(request.CustomerId, request.TemplateId, request.LoyaltyLevelId, request.IsActive);

        await _unitOfWork.NotificationLogRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.NotificationLogNotInserted);
    }
}