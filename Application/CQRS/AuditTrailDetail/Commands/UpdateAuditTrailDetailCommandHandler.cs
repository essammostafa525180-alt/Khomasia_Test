using Application.Abstractions;

namespace Application.CQRS.AuditTrailDetail.Commands;

public class UpdateAuditTrailDetailCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? AuditTrailId { get; set; }
        public string? Property { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string? ReferenceTable { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAuditTrailDetailCommandHandler : ICommandHandler<UpdateAuditTrailDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAuditTrailDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAuditTrailDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AuditTrailDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AuditTrailDetailNotFound);

        entity.Update(request.AuditTrailId, request.Property, request.OldValue, request.NewValue, request.ReferenceTable, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AuditTrailDetailNotUpdated);
    }
}