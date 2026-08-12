namespace Application.CQRS.BatteryType;

public record BatteryTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);