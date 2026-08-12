namespace Application.CQRS.AssignCostCenterToSector;

public record AssignCostCenterToSectorDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? SectorFk,
    int? CostCenterFk
);