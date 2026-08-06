namespace Application.CQRS.VendorOrderVendorSelection;

public record VendorOrderVendorSelectionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderFk,
    int? VendorFk,
    bool IsSelected
);