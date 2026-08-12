using Application.Abstractions;

namespace Application.CQRS.SecRoleSecurableValue.Commands;

public class DeleteSecRoleSecurableValueCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecRoleSecurableValueCommandHandler : ICommandHandler<DeleteSecRoleSecurableValueCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecRoleSecurableValueCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecRoleSecurableValueCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleSecurableValueRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRoleSecurableValueNotFound);

        _unitOfWork.SecRoleSecurableValueRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRoleSecurableValueNotDeleted);
    }
}