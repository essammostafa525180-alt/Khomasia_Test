namespace Application.CQRS.MaterialCategory;

public record MaterialCategoryDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? MaterialGroupFk,
    string? Code,
    string? Name,
    string? NameAr
);