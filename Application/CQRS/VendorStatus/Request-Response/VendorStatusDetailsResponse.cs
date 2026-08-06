namespace Application.CQRS.VendorStatus;

public record VendorStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);