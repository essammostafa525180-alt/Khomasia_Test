using Application.Abstractions;

namespace Application.CQRS.SecRoleViewAction.Commands;

public class DeleteSecRoleViewActionCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecRoleViewActionCommandHandler : ICommandHandler<DeleteSecRoleViewActionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecRoleViewActionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecRoleViewActionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleViewActionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRoleViewActionNotFound);

        _unitOfWork.SecRoleViewActionRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRoleViewActionNotDeleted);
    }
}