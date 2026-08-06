using Application.Abstractions;

namespace Application.CQRS.SecRole.Commands;

public class DeleteSecRoleCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecRoleCommandHandler : ICommandHandler<DeleteSecRoleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRoleNotFound);

        _unitOfWork.SecRoleRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRoleNotDeleted);
    }
}