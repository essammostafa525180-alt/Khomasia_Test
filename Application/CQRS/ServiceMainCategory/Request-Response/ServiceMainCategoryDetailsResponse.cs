namespace Application.CQRS.ServiceMainCategory;

public record ServiceMainCategoryDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    int? FinanceCostCenterId
);