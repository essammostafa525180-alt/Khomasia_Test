namespace Application.CQRS.AssignVendorSpecialization;

public record AssignVendorSpecializationDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorFk,
    int? VendorSpecializationFk
);