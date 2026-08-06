namespace Application.CQRS.ApprovalMatrixDetail;

public record ApprovalMatrixDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? ApprovalMatrixFk,
    int? ApprovalMatrixConfigDetailFk,
    int ApprovalStatusFk,
    DateTime? ApprovalDate,
    int? UserFk,
    string? Email
);