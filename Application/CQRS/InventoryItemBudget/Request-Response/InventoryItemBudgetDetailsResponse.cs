namespace Application.CQRS.InventoryItemBudget;

public record InventoryItemBudgetDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? CompanyFk,
    int? ProjectFk,
    int? LocationFk,
    int? ServiceMainCategoryFk,
    int? ScopeFk
);