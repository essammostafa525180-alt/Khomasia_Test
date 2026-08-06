namespace Application.CQRS.StockCountPlanStatus;

public record StockCountPlanStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);