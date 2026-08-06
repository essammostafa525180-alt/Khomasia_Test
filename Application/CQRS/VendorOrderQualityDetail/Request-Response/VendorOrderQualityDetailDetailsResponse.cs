namespace Application.CQRS.VendorOrderQualityDetail;

public record VendorOrderQualityDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderQualityFk,
    int? VendorOrderDetailFk,
    long? InventoryItemFk,
    decimal? ReceivedQuantity,
    decimal? LandedCost
);