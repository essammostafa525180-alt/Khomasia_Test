namespace Application.CQRS.SecRoleModule;

public record SecRoleModuleDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int SecRoleId,
    int SecModuleId,
    bool? IsAllowed
);