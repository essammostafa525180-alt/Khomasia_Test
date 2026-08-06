using Application.Abstractions;

namespace Application.CQRS.SecRoleModelAttribute.Commands;

public class DeleteSecRoleModelAttributeCommand : ICommand<Result>
{
    public int Id { get; set; }
}
internal class DeleteSecRoleModelAttributeCommandHandler : ICommandHandler<DeleteSecRoleModelAttributeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSecRoleModelAttributeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSecRoleModelAttributeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleModelAttributeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRoleModelAttributeNotFound);

        _unitOfWork.SecRoleModelAttributeRepository.SoftDelete(entity);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRoleModelAttributeNotDeleted);
    }
}