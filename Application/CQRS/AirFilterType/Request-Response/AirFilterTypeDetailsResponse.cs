namespace Application.CQRS.AirFilterType;

public record AirFilterTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);