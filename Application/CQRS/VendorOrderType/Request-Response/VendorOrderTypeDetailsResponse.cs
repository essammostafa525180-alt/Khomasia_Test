namespace Application.CQRS.VendorOrderType;

public record VendorOrderTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);