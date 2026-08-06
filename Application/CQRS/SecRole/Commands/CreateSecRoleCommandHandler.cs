using Application.Abstractions;

namespace Application.CQRS.SecRole.Commands;

public class CreateSecRoleCommand : ICommand<Result<int>>
{
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public bool? IsAdmin { get; set; }
        public string? RoleNameAr { get; set; }
        public bool? SingleSession { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecRoleCommandHandler : ICommandHandler<CreateSecRoleCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecRoleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecRoleCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecRole.Create(request.RoleId, request.RoleName, request.IsAdmin, request.RoleNameAr, request.SingleSession, request.IsActive);

        await _unitOfWork.SecRoleRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecRoleNotInserted);
    }
}