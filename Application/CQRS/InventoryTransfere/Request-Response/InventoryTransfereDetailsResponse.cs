namespace Application.CQRS.InventoryTransfere;

public record InventoryTransfereDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);