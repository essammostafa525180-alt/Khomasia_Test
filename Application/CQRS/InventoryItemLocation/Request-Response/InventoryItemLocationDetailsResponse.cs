namespace Application.CQRS.InventoryItemLocation;

public record InventoryItemLocationDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);