namespace Application.CQRS.PoserviceOutsource;

public record PoserviceOutsourceDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? PoserviceFk,
    int? WorkerTypeFk,
    int? EmployeeJobFk,
    int? Quantity,
    decimal? CostPerDay,
    decimal? TotalCost,
    int? ContractTaskEmployeeId
);