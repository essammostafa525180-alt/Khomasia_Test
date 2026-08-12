using Application.Abstractions;

namespace Application.CQRS.AssignCostCenterToSector.Commands;

public class CreateAssignCostCenterToSectorCommand : ICommand<Result<int>>
{
        public int? SectorFk { get; set; }
        public int? CostCenterFk { get; set; }
        public bool IsActive { get; set; }
}
internal class CreateAssignCostCenterToSectorCommandHandler : ICommandHandler<CreateAssignCostCenterToSectorCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssignCostCenterToSectorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssignCostCenterToSectorCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.AssignCostCenterToSector.Create(request.SectorFk, request.CostCenterFk, request.IsActive);

        await _unitOfWork.AssignCostCenterToSectorRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssignCostCenterToSectorNotInserted);
    }
}