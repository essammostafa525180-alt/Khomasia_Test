namespace Application.CQRS.AssetCountIssue;

public record AssetCountIssueDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? IssueNumber,
    int? AssetCountDetailFk,
    int? AssetCountIssueStatusFk,
    string? Notes
);