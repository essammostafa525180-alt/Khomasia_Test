namespace Application.CQRS.InventoryYear;

public record InventoryYearDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name
);