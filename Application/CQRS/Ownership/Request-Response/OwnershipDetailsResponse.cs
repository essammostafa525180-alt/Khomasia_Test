namespace Application.CQRS.Ownership;

public record OwnershipDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);