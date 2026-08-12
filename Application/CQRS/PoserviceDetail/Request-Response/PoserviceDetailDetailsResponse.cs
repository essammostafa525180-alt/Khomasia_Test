namespace Application.CQRS.PoserviceDetail;

public record PoserviceDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? PoserviceFk,
    int? ServiceTypeFk,
    int? ServiceMainCategoryFk,
    int? ServiceCategoryFk,
    int? ServiceSubCategoryFk,
    int? ServiceFk,
    int? Quantity,
    decimal? CostPerService,
    decimal? TotalCost,
    int? ContractServiceId
);