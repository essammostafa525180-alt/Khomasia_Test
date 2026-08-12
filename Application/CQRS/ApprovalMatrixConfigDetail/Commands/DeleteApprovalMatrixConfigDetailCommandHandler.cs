using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrixConfigDetail.Commands;

public class DeleteApprovalMatrixConfigDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteApprovalMatrixConfigDetailCommandHandler : ICommandHandler<DeleteApprovalMatrixConfigDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteApprovalMatrixConfigDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteApprovalMatrixConfigDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixConfigDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalMatrixConfigDetailNotFound);

        _unitOfWork.ApprovalMatrixConfigDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalMatrixConfigDetailNotDeleted);
    }
}