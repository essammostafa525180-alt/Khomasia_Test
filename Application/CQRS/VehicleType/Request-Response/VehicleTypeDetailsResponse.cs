namespace Application.CQRS.VehicleType;

public record VehicleTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    decimal? InteriorVolume,
    int? EquipmentTypeFk,
    string? Description,
    decimal? InteriorLenght,
    decimal? ExteriorLenght,
    decimal? InteriorWidth,
    decimal? ExteriorWidth,
    decimal? InteriorHeight,
    decimal? ExteriorHeight,
    decimal? TareWeight,
    decimal? MaxGrossWeight
);