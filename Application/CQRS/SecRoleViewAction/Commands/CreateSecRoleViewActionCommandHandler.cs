using Application.Abstractions;

namespace Application.CQRS.SecRoleViewAction.Commands;

public class CreateSecRoleViewActionCommand : ICommand<Result<int>>
{
        public int ViewActionId { get; set; }
        public int RoleId { get; set; }
        public bool? IsAllow { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateSecRoleViewActionCommandHandler : ICommandHandler<CreateSecRoleViewActionCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSecRoleViewActionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateSecRoleViewActionCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.SecurityAggregate.SecRoleViewAction.Create(request.ViewActionId, request.RoleId, request.IsAllow, request.IsActive);

        await _unitOfWork.SecRoleViewActionRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.SecRoleViewActionNotInserted);
    }
}