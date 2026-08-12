using Application.Abstractions;

namespace Application.CQRS.AuditTrail.Commands;

public class UpdateAuditTrailCommand : ICommand<Result>
{
        public int Id { get; set; }
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
internal class UpdateAuditTrailCommandHandler : ICommandHandler<UpdateAuditTrailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAuditTrailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAuditTrailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AuditTrailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AuditTrailNotFound);

        entity.Update(request.TableName, request.Action, request.ExecutedAt, request.UserId, request.EntityId, request.ClientComputerName, request.ClientIp, request.ParentAuditTrailId, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AuditTrailNotUpdated);
    }
}