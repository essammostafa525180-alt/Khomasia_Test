namespace Application.CQRS.PurchaseOrderService;

public record PurchaseOrderServiceDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? OrderScreenFk,
    int? PoserviceTypeFk,
    int? VendorOrderTypeFk,
    int? VendorFk,
    int? Prfk,
    string? OrderNo,
    DateTime? RequestDate,
    DateTime? OrderDate,
    int? OrderByUserFk,
    int? ProjectFk,
    int? LocationFk,
    int? ServiceMainCategoryFk,
    int? ScopeFk,
    int? VendorOrderStatusFk,
    int? PaymentTermFk,
    string? PaymentTerms,
    bool? IsApproved,
    int? Duration,
    int? CompanyFk,
    int? ContractId,
    DateTime? StartDate,
    DateTime? EndDate,
    string? ContractCode,
    decimal? TotalCost,
    string? Description,
    int? InventoryItemBudgetFk
);