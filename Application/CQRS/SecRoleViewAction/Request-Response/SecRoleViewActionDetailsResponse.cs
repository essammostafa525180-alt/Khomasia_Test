namespace Application.CQRS.SecRoleViewAction;

public record SecRoleViewActionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int ViewActionId,
    int RoleId,
    bool? IsAllow
);