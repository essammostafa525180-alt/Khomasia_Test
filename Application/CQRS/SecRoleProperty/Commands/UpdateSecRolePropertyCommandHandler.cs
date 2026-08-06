using Application.Abstractions;

namespace Application.CQRS.SecRoleProperty.Commands;

public class UpdateSecRolePropertyCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? PropertyId { get; set; }
        public int? Mode { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecRolePropertyCommandHandler : ICommandHandler<UpdateSecRolePropertyCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecRolePropertyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecRolePropertyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRolePropertyRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRolePropertyNotFound);

        entity.Update(request.RoleId, request.PropertyId, request.Mode, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRolePropertyNotUpdated);
    }
}