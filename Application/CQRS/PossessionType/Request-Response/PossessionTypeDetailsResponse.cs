namespace Application.CQRS.PossessionType;

public record PossessionTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);