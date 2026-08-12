namespace Application.CQRS.ServiceCategory;

public record ServiceCategoryDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    int? ServiceTypeFk,
    int? ServiceMainCategoryFk,
    int? CompanyFk,
    bool? IsFelKhedma
);