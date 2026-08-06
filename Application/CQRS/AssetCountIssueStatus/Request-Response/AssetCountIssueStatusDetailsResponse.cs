namespace Application.CQRS.AssetCountIssueStatus;

public record AssetCountIssueStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);