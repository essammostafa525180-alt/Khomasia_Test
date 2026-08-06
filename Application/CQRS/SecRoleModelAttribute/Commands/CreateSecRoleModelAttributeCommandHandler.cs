using Application.Abstractions;

namespace Application.CQRS.SecRoleModelAttribute.Commands;

public class CreateSecRoleModelAttributeCommand : ICommand<Result<int>>
{
        public int RoleId { get; set; }
        public int ModelAttributeId { get; set; }
        public int? Mode { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecRoleModelAttributeCommandHandler : ICommandHandler<CreateSecRoleModelAttributeCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecRoleModelAttributeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecRoleModelAttributeCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecRoleModelAttribute.Create(request.RoleId, request.ModelAttributeId, request.Mode, request.IsActive);

        await _unitOfWork.SecRoleModelAttributeRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecRoleModelAttributeNotInserted);
    }
}