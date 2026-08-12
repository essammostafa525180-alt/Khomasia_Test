namespace Application.CQRS.InventoryItemStatus;

public record InventoryItemStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);