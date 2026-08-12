namespace Application.CQRS.SecRoleModelAttribute;

public record SecRoleModelAttributeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int RoleId,
    int ModelAttributeId,
    int? Mode
);