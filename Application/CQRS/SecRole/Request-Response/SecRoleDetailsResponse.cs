namespace Application.CQRS.SecRole;

public record SecRoleDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int RoleId,
    string? RoleName,
    bool? IsAdmin,
    string? RoleNameAr,
    bool? SingleSession
);