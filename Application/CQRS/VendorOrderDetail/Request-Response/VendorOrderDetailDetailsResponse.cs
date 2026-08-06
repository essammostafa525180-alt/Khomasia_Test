namespace Application.CQRS.VendorOrderDetail;

public record VendorOrderDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);