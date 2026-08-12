using Application.Abstractions;

namespace Application.CQRS.SecRoleProperty.Commands;

public class DeleteSecRolePropertyCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecRolePropertyCommandHandler : ICommandHandler<DeleteSecRolePropertyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecRolePropertyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecRolePropertyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRolePropertyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRolePropertyNotFound);

        _unitOfWork.SecRolePropertyRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRolePropertyNotDeleted);
    }
}