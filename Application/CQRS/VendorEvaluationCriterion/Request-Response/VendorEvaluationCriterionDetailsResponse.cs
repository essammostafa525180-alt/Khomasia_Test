namespace Application.CQRS.VendorEvaluationCriterion;

public record VendorEvaluationCriterionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);