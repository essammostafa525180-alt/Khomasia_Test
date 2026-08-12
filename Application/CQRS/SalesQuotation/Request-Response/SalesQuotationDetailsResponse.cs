namespace Application.CQRS.SalesQuotation;

public record SalesQuotationDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? CompanyFk,
    int? RequestForQuotationFk,
    string? OrderNo,
    DateTime? OrderDate,
    DateOnly? ExpectedDeliveryDate,
    int? CustomerFk,
    string? Notes,
    decimal? TotalRatio,
    decimal? TotalCost
);