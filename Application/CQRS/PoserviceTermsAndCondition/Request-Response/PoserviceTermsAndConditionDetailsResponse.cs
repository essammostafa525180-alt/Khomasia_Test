namespace Application.CQRS.PoserviceTermsAndCondition;

public record PoserviceTermsAndConditionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? PoserviceFk,
    int? TermsAndConditionFk,
    string? Description,
    bool IsActive1
);