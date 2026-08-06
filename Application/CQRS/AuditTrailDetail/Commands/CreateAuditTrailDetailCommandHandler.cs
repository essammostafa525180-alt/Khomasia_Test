using Application.Abstractions;

namespace Application.CQRS.AuditTrailDetail.Commands;

public class CreateAuditTrailDetailCommand : ICommand<Result<int>>
{
        public int? AuditTrailId { get; set; }
        public string? Property { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string? ReferenceTable { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAuditTrailDetailCommandHandler : ICommandHandler<CreateAuditTrailDetailCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAuditTrailDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAuditTrailDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AuditAggregate.AuditTrailDetail.Create(request.AuditTrailId, request.Property, request.OldValue, request.NewValue, request.ReferenceTable, request.IsActive);

        await _unitOfWork.AuditTrailDetailRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AuditTrailDetailNotInserted);
    }
}