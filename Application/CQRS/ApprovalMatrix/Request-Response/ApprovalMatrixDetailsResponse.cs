namespace Application.CQRS.ApprovalMatrix;

public record ApprovalMatrixDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? ScreenFk,
    int? EntityId,
    int? ApprovalMatrixConfigFk,
    int ApprovalStatusFk,
    DateTime? ApprovalDate
);