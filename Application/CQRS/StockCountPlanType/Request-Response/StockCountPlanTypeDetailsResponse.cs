namespace Application.CQRS.StockCountPlanType;

public record StockCountPlanTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);