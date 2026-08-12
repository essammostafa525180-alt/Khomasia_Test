using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountPlan.Commands;

public class UpdateInventoryStockCountPlanCommand : ICommand<Result>
{
        public int Id { get; set; }
        public string? CountPlanNo { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public int? StockCountPlanStatusFk { get; set; }
        public int? StockCountPlanTypeFk { get; set; }
        public int? AssignedToUserFk { get; set; }
        public bool IsActive { get; set; }
}
internal class UpdateInventoryStockCountPlanCommandHandler : ICommandHandler<UpdateInventoryStockCountPlanCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateInventoryStockCountPlanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateInventoryStockCountPlanCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.InventoryStockCountPlanRepository.GetByIdAsync(request.Id);

        if (entity is null || entity.IsDeleted)
            return Result.Failure(Errors.InventoryStockCountPlanNotFound);

        entity.Update(request.CountPlanNo, request.Name, request.NameAr, request.PlanDate, request.ExecutionDate, request.StockCountPlanStatusFk, request.StockCountPlanTypeFk, request.AssignedToUserFk, request.IsActive);

        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Success() : Result.Failure(Errors.InventoryStockCountPlanNotUpdated);
    }
}