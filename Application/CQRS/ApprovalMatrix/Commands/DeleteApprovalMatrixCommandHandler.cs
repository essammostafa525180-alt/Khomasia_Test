using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrix.Commands;

public class DeleteApprovalMatrixCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteApprovalMatrixCommandHandler : ICommandHandler<DeleteApprovalMatrixCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteApprovalMatrixCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteApprovalMatrixCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalMatrixNotFound);

        _unitOfWork.ApprovalMatrixRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalMatrixNotDeleted);
    }
}