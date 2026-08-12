namespace Application.CQRS.ContactType;

public record ContactTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr,
    DateTime? UpdatedOn
);