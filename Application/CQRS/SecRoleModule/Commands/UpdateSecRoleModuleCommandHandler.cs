using Application.Abstractions;

namespace Application.CQRS.SecRoleModule.Commands;

public class UpdateSecRoleModuleCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int SecRoleId { get; set; }
        public int SecModuleId { get; set; }
        public bool? IsAllowed { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecRoleModuleCommandHandler : ICommandHandler<UpdateSecRoleModuleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecRoleModuleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecRoleModuleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleModuleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRoleModuleNotFound);

        entity.Update(request.SecRoleId, request.SecModuleId, request.IsAllowed, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRoleModuleNotUpdated);
    }
}