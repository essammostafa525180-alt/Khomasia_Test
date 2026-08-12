namespace Application.CQRS.VendorOrderReceiveDetail;

public record VendorOrderReceiveDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderReceiveFk,
    int? VendorOrderQualityDetailFk,
    long? InventoryItemFk,
    decimal? ReceivedQuantity,
    decimal? ReturnedQuantity,
    int? FromSerialize,
    int? ToSerialize,
    string? Notes,
    string? PartNo,
    string? ManufacturerCountry
);