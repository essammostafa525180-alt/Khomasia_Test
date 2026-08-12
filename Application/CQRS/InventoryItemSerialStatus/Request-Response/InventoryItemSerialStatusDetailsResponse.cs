namespace Application.CQRS.InventoryItemSerialStatus;

public record InventoryItemSerialStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);