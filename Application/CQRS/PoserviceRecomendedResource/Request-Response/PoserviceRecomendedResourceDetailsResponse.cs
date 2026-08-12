namespace Application.CQRS.PoserviceRecomendedResource;

public record PoserviceRecomendedResourceDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int PoserviceFk,
    int? ContractFk,
    int? EmployeeJobFk,
    int? VendorFk
);