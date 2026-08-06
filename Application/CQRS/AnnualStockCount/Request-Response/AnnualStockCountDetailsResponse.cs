namespace Application.CQRS.AnnualStockCount;

public record AnnualStockCountDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? YearId,
    int? StoreFk,
    bool IsCompleted
);