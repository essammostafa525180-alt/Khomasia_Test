namespace Application.CQRS.Customer;

public record CustomerDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    string? Phone,
    string? Address,
    string? ContactPerson,
    string? CommercialRecord,
    string? OtherVendor,
    int? CompanyFk,
    int? SectorFk
);