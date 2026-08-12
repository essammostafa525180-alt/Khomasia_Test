namespace Application.CQRS.VendorSpecialization;

public record VendorSpecializationDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);