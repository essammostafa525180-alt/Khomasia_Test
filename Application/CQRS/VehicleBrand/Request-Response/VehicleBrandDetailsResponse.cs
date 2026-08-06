namespace Application.CQRS.VehicleBrand;

public record VehicleBrandDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);