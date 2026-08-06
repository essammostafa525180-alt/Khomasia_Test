namespace Application.CQRS.VendorOrderVendorSuggested;

public record VendorOrderVendorSuggestedDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderFk,
    string? VendorName,
    string? Address,
    string? Phone,
    string? Email,
    string? Website
);