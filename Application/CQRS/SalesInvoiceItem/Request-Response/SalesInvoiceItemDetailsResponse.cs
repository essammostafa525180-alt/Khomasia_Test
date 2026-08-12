namespace Application.CQRS.SalesInvoiceItem;

public record SalesInvoiceItemDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? SalesInvoiceId,
    int? ProductId,
    int? Quantity,
    decimal? Price,
    decimal? Discount,
    decimal? NetAmount,
    DateTime? UpdatedOn,
    int? UpdatedBy
);