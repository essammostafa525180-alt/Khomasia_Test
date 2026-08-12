namespace Application.CQRS.InventoryItemBudgetDetail;

public record InventoryItemBudgetDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryItemBudgetFk,
    int? ItemTypeFk,
    long? InventoryItemFk,
    int? BudgetQuantity,
    decimal? BudgetCost
);