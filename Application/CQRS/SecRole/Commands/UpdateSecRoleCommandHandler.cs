using Application.Abstractions;

namespace Application.CQRS.SecRole.Commands;

public class UpdateSecRoleCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public bool? IsAdmin { get; set; }
        public string? RoleNameAr { get; set; }
        public bool? SingleSession { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateSecRoleCommandHandler : ICommandHandler<UpdateSecRoleCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSecRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateSecRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.SecRoleRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.SecRoleNotFound);

        entity.Update(request.RoleId, request.RoleName, request.IsAdmin, request.RoleNameAr, request.SingleSession, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.SecRoleNotUpdated);
    }
}