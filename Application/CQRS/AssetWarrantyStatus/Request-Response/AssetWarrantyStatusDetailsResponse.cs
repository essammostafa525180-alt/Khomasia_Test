namespace Application.CQRS.AssetWarrantyStatus;

public record AssetWarrantyStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);