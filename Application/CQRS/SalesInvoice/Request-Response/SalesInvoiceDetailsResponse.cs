namespace Application.CQRS.SalesInvoice;

public record SalesInvoiceDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? CustomerId,
    int? UserId,
    string? Address,
    string? ContactPerson,
    decimal? Vatpercentage,
    decimal? Vatamount,
    decimal? TotalAmount,
    DateTime? UpdatedOn,
    int? UpdatedBy
);