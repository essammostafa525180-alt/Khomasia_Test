using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrixDetail.Commands;

public class DeleteApprovalMatrixDetailCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteApprovalMatrixDetailCommandHandler : ICommandHandler<DeleteApprovalMatrixDetailCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteApprovalMatrixDetailCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteApprovalMatrixDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixDetailRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalMatrixDetailNotFound);

        _unitOfWork.ApprovalMatrixDetailRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalMatrixDetailNotDeleted);
    }
}