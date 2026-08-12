namespace Application.CQRS.AssetMaintenanceStatus;

public record AssetMaintenanceStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);