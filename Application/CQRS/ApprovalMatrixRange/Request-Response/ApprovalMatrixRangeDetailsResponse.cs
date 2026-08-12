namespace Application.CQRS.ApprovalMatrixRange;

public record ApprovalMatrixRangeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    decimal? RangeFrom,
    decimal? RangeTo
);