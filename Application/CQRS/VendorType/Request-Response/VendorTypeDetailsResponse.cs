namespace Application.CQRS.VendorType;

public record VendorTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);