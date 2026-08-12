namespace Application.CQRS.VehicleColor;

public record VehicleColorDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);