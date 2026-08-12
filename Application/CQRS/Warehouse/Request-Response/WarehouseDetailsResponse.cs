namespace Application.CQRS.Warehouse;

public record WarehouseDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int WarehouseTypeFk,
    string? Code,
    string? Name,
    string? Description,
    string? Address
);
