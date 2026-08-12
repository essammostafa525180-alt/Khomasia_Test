namespace Application.CQRS.ZoneStatus;

public record ZoneStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);