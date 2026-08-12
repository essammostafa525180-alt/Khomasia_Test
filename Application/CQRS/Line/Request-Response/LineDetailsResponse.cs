namespace Application.CQRS.Line;

public record LineDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr,
    int? ProjectFk
);