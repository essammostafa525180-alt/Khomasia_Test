namespace Application.CQRS.MaterialGroup;

public record MaterialGroupDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? ShortName,
    string? Name,
    string? NameAr
);