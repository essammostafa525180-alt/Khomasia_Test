namespace Application.CQRS.WarrantyStatus;

public record WarrantyStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);