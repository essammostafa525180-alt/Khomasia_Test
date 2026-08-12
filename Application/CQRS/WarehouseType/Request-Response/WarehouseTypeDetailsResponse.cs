namespace Application.CQRS.WarehouseType;

public record WarehouseTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? Description
);
