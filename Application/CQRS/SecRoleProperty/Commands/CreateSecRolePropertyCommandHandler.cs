using Application.Abstractions;

namespace Application.CQRS.SecRoleProperty.Commands;

public class CreateSecRolePropertyCommand : ICommand<Result<int>>
{
        public int? RoleId { get; set; }
        public int? PropertyId { get; set; }
        public int? Mode { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecRolePropertyCommandHandler : ICommandHandler<CreateSecRolePropertyCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecRolePropertyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecRolePropertyCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Entities.SecRoleProperty.Create(request.RoleId, request.PropertyId, request.Mode, request.IsActive);

        await _unitOfWork.SecRolePropertyRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecRolePropertyNotInserted);
    }
}