namespace Application.CQRS.VehicleOption;

public record VehicleOptionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);