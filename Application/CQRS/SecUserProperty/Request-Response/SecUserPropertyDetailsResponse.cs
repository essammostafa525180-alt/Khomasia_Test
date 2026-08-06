namespace Application.CQRS.SecUserProperty;

public record SecUserPropertyDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? UserId,
    int? PropertyId,
    int? Mode
);