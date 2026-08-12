namespace Application.CQRS.VendorOrderStatus;

public record VendorOrderStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);