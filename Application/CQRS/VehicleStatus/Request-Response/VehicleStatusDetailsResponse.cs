namespace Application.CQRS.VehicleStatus;

public record VehicleStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    string? Description
);