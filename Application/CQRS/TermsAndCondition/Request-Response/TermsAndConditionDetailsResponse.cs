namespace Application.CQRS.TermsAndCondition;

public record TermsAndConditionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);