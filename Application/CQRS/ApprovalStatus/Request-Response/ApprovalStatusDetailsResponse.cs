namespace Application.CQRS.ApprovalStatus;

public record ApprovalStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);