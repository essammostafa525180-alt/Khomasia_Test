namespace Application.CQRS.InventoryStockCountPlan;

public record InventoryStockCountPlanDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? CountPlanNo,
    string? Name,
    string? NameAr,
    DateTime? PlanDate,
    DateTime? ExecutionDate,
    int? StockCountPlanStatusFk,
    int? StockCountPlanTypeFk,
    int? AssignedToUserFk
);