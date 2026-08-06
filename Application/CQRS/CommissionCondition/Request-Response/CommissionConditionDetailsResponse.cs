namespace Application.CQRS.CommissionCondition;

public record CommissionConditionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);