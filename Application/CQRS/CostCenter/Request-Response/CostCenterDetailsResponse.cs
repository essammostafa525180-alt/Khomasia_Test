namespace Application.CQRS.CostCenter;

public record CostCenterDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);