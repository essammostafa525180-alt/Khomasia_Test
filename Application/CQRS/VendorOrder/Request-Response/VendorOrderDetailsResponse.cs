namespace Application.CQRS.VendorOrder;

public record VendorOrderDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);