namespace Application.CQRS.SalesQuotationDetail;

public record SalesQuotationDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? SalesQuotationFk,
    int? RequestForQuotationDetailFk,
    long? InventoryItemFk,
    decimal? VendorCostPrice,
    decimal? CostPriceRatio,
    decimal? CostPrice,
    decimal? OrderedQuantity,
    decimal? TotalPrice
);