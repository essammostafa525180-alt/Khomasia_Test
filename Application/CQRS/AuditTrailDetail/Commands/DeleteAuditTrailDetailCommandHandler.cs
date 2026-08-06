using Application.Abstractions;

namespace Application.CQRS.AuditTrailDetail.Commands;

public class DeleteAuditTrailDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteAuditTrailDetailCommandHandler : ICommandHandler<DeleteAuditTrailDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAuditTrailDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteAuditTrailDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AuditTrailDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AuditTrailDetailNotFound);

        _unitOfWork.AuditTrailDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AuditTrailDetailNotDeleted);
    }
}