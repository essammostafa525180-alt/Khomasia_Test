using Application.Abstractions;

namespace Application.CQRS.SecRoleModelAttribute.Commands;

public class UpdateSecRoleModelAttributeCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ModelAttributeId { get; set; }
        public int? Mode { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecRoleModelAttributeCommandHandler : ICommandHandler<UpdateSecRoleModelAttributeCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecRoleModelAttributeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecRoleModelAttributeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleModelAttributeRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRoleModelAttributeNotFound);

        entity.Update(request.RoleId, request.ModelAttributeId, request.Mode, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRoleModelAttributeNotUpdated);
    }
}