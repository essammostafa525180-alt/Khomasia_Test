using Application.Abstractions;

namespace Application.CQRS.SecRoleModule.Commands;

public class CreateSecRoleModuleCommand : ICommand<Result<int>>
{
        public int SecRoleId { get; set; }
        public int SecModuleId { get; set; }
        public bool? IsAllowed { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecRoleModuleCommandHandler : ICommandHandler<CreateSecRoleModuleCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecRoleModuleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecRoleModuleCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecRoleModule.Create(request.SecRoleId, request.SecModuleId, request.IsAllowed, request.IsActive);

        await _unitOfWork.SecRoleModuleRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecRoleModuleNotInserted);
    }
}