namespace Application.CQRS.AssignVendorEvaluationCriterion;

public record AssignVendorEvaluationCriterionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorFk,
    int? VendorEvaluationCriteriaFk,
    int? RankFk
);