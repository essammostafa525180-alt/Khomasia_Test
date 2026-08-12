namespace Application.CQRS.ServiceSubCategory;

public record ServiceSubCategoryDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    int? ServiceTypeFk,
    int? ServiceMainCategoryFk,
    int? ServiceCategoryFk,
    int? CompanyFk
);