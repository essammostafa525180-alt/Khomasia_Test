namespace Application.CQRS.Pruser;

public record PruserDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int ApprovalScreenFk,
    int UserFk
);