using Domain.Entities;

namespace Application.CQRS.StorageUnit;

public record StorageUnitDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int WarehouseFk,
    StorageUnitType Type,
    string? Code,
    string? Name,
    string? Description,
    decimal? Capacity,
    string? CapacityUnit
);
