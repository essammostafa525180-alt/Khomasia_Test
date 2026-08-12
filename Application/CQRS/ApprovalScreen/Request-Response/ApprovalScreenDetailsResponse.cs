namespace Application.CQRS.ApprovalScreen;

public record ApprovalScreenDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);