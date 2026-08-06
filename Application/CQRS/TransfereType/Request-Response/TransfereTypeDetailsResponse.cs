namespace Application.CQRS.TransfereType;

public record TransfereTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);