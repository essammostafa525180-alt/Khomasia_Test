namespace Application.CQRS.Sector;

public record SectorDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);