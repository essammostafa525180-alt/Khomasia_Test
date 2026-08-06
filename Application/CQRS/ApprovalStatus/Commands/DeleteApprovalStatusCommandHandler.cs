using Application.Abstractions;

namespace Application.CQRS.ApprovalStatus.Commands;

public class DeleteApprovalStatusCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteApprovalStatusCommandHandler : ICommandHandler<DeleteApprovalStatusCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteApprovalStatusCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteApprovalStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalStatusRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalStatusNotFound);

        _unitOfWork.ApprovalStatusRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalStatusNotDeleted);
    }
}