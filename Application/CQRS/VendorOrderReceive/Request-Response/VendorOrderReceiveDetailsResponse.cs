namespace Application.CQRS.VendorOrderReceive;

public record VendorOrderReceiveDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);