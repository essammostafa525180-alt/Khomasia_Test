namespace Application.CQRS.Service;

public record ServiceDetailsResponse
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
    int? ServiceSubCategoryFk
);