namespace Application.CQRS.MaterialSubCategory;

public record MaterialSubCategoryDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? MaterialGroupFk,
    int? MaterialCategoryFk,
    string? Code,
    string? Name,
    string? NameAr
);