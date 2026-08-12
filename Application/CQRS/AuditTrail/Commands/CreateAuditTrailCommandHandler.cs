using Application.Abstractions;

namespace Application.CQRS.AuditTrail.Commands;

public class CreateAuditTrailCommand : ICommand<Result<int>>
{
        public string? TableName { get; set; }
        public string? Action { get; set; }
        public DateTime? ExecutedAt { get; set; }
        public int? UserId { get; set; }
        public int? EntityId { get; set; }
        public string? ClientComputerName { get; set; }
        public string? ClientIp { get; set; }
        public int? ParentAuditTrailId { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAuditTrailCommandHandler : ICommandHandler<CreateAuditTrailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAuditTrailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAuditTrailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AuditAggregate.AuditTrail.Create(request.TableName, request.Action, request.ExecutedAt, request.UserId, request.EntityId, request.ClientComputerName, request.ClientIp, request.ParentAuditTrailId, request.IsActive);

        await _unitOfWork.AuditTrailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AuditTrailNotInserted);
    }
}