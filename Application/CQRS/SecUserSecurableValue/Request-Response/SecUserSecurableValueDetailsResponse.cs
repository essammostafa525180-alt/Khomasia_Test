namespace Application.CQRS.SecUserSecurableValue;

public record SecUserSecurableValueDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Value,
    int? SecUserPropertyId
);