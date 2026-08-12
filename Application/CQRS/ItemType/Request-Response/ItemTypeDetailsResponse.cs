namespace Application.CQRS.ItemType;

public record ItemTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    bool? Axsynced
);