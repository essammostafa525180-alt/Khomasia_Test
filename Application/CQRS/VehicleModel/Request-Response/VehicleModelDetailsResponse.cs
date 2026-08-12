namespace Application.CQRS.VehicleModel;

public record VehicleModelDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    int? VehicleBrandFk,
    int? YearFk
);