namespace Application.CQRS.SecRoleSecurableValue;

public record SecRoleSecurableValueDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Value,
    int? SecRolePropertyId
);