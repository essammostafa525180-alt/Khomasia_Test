namespace Application.CQRS.AllowedCompany;

public record AllowedCompanyDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? CompanyFk,
    int? UserFk
);