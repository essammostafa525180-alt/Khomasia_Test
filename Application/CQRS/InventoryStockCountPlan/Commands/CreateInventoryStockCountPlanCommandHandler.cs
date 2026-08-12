using Application.Abstractions;

namespace Application.CQRS.InventoryStockCountPlan.Commands;

public class CreateInventoryStockCountPlanCommand : ICommand<Result<int>>
{
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
internal class CreateInventoryStockCountPlanCommandHandler : ICommandHandler<CreateInventoryStockCountPlanCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateInventoryStockCountPlanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateInventoryStockCountPlanCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.InventoryStockCountAggregate.InventoryStockCountPlan.Create(request.CountPlanNo, request.Name, request.NameAr, request.PlanDate, request.ExecutionDate, request.StockCountPlanStatusFk, request.StockCountPlanTypeFk, request.AssignedToUserFk, request.IsActive);

        await _unitOfWork.InventoryStockCountPlanRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.InventoryStockCountPlanNotInserted);
    }
}