namespace Application.CQRS.ApprovalMatrixConfigDetail;

public record ApprovalMatrixConfigDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? ApprovalMatrixConfigFk,
    int? ApprovalMatrixRangeFk,
    int StepNo,
    string? StepName,
    string? StepNameAr,
    int? UserFk,
    string? Email
);