namespace Application.CQRS.SecUserViewAction;

public record SecUserViewActionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int UserId,
    int ViewActionId,
    bool? IsAllow
);