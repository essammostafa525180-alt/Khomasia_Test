using Application.Abstractions;

namespace Application.CQRS.ApprovalMatrixConfig.Commands;

public class DeleteApprovalMatrixConfigCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteApprovalMatrixConfigCommandHandler : ICommandHandler<DeleteApprovalMatrixConfigCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteApprovalMatrixConfigCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteApprovalMatrixConfigCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalMatrixConfigRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalMatrixConfigNotFound);

        _unitOfWork.ApprovalMatrixConfigRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalMatrixConfigNotDeleted);
    }
}