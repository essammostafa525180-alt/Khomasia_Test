using Application.Abstractions;

namespace Application.CQRS.SecRoleModule.Commands;

public class DeleteSecRoleModuleCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecRoleModuleCommandHandler : ICommandHandler<DeleteSecRoleModuleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecRoleModuleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecRoleModuleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleModuleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRoleModuleNotFound);

        _unitOfWork.SecRoleModuleRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRoleModuleNotDeleted);
    }
}