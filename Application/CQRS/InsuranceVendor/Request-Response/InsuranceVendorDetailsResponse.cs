namespace Application.CQRS.InsuranceVendor;

public record InsuranceVendorDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);