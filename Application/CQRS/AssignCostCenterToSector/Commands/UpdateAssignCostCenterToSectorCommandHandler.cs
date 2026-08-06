using Application.Abstractions;

namespace Application.CQRS.AssignCostCenterToSector.Commands;

public class UpdateAssignCostCenterToSectorCommand : ICommand<Result>
{
        public int Id { get; set; }
        public int? SectorFk { get; set; }
        public int? CostCenterFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateAssignCostCenterToSectorCommandHandler : ICommandHandler<UpdateAssignCostCenterToSectorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAssignCostCenterToSectorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateAssignCostCenterToSectorCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.AssignCostCenterToSectorRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.AssignCostCenterToSectorNotFound);

        entity.Update(request.SectorFk, request.CostCenterFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.AssignCostCenterToSectorNotUpdated);
    }
}