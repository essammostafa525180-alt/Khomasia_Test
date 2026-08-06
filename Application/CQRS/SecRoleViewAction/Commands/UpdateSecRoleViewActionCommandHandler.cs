using Application.Abstractions;

namespace Application.CQRS.SecRoleViewAction.Commands;

public class UpdateSecRoleViewActionCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int ViewActionId { get; set; }
        public int RoleId { get; set; }
        public bool? IsAllow { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecRoleViewActionCommandHandler : ICommandHandler<UpdateSecRoleViewActionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecRoleViewActionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecRoleViewActionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleViewActionRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRoleViewActionNotFound);

        entity.Update(request.ViewActionId, request.RoleId, request.IsAllow, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRoleViewActionNotUpdated);
    }
}