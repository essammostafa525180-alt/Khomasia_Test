namespace Application.CQRS.VendorOrderQuality;

public record VendorOrderQualityDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);