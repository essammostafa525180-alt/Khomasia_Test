namespace Application.CQRS.InventroyItemRequestWithdrawDetail;

public record InventroyItemRequestWithdrawDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? RequestWfk,
    long? InventoryItemFk,
    decimal? RequestedQuantity,
    decimal? PickedQuantity,
    decimal? DeliveredQuantity,
    decimal? ReturnedQuantity,
    decimal? ScrapedQuantity,
    int? RequestLineItemStatusFk,
    int? FromSerial,
    int? ToSerial,
    int? IntegrationId,
    bool? IsSync,
    decimal? LastPurchasePrice,
    decimal? AvgCost
);