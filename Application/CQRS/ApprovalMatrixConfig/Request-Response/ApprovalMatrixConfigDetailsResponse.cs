namespace Application.CQRS.ApprovalMatrixConfig;

public record ApprovalMatrixConfigDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? ScreenFk,
    int? CompanyFk,
    int? ProjectFk,
    int? ScopeFk,
    int? ServiceMainCategoryFk,
    int? LocationFk
);