using Application.Abstractions;

namespace Application.CQRS.ApprovalScreen.Commands;

public class DeleteApprovalScreenCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteApprovalScreenCommandHandler : ICommandHandler<DeleteApprovalScreenCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteApprovalScreenCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteApprovalScreenCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.ApprovalScreenRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.ApprovalScreenNotFound);

        _unitOfWork.ApprovalScreenRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.ApprovalScreenNotDeleted);
    }
}