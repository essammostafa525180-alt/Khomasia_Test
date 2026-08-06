namespace Application.CQRS.RwDeliveredQuantity;

public record RwDeliveredQuantityDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? RequestWdfk,
    decimal? DeliveredQuantity,
    decimal? ScrapedQuantity,
    DateTime? DeliveredDate,
    bool? Axsynced,
    bool? IsReceived,
    decimal? MaintainableQuantity,
    string? DeliveredNumber
);