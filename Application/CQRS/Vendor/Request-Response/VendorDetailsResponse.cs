namespace Application.CQRS.Vendor;

public record VendorDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);