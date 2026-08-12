namespace Application.CQRS.InventoryItemEquivalentSp;

public record InventoryItemEquivalentSpDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    long? InventoryItemFk,
    int? EquivalentItemFk
);