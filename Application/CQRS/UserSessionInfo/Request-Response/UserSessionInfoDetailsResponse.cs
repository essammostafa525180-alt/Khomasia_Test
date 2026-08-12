namespace Application.CQRS.UserSessionInfo;

public record UserSessionInfoDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int UserId,
    DateTime LastHit,
    DateTime ExpireAt,
    bool? RemeberMe,
    string? Language,
    string? ValidModules,
    Guid UserToken
);