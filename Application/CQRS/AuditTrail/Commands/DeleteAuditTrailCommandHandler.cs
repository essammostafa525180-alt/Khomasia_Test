using Application.Abstractions;

namespace Application.CQRS.AuditTrail.Commands;

public class DeleteAuditTrailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAuditTrailCommandHandler : ICommandHandler<DeleteAuditTrailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAuditTrailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAuditTrailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AuditTrailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AuditTrailNotFound);

        _unitOfWork.AuditTrailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AuditTrailNotDeleted);
    }
}