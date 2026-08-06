namespace Application.CQRS.SecRoleProperty;

public record SecRolePropertyDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? RoleId,
    int? PropertyId,
    int? Mode
);