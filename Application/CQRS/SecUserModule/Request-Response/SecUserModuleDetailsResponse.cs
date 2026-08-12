namespace Application.CQRS.SecUserModule;

public record SecUserModuleDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int UserId,
    int SecModuleId,
    bool? IsAllowed
);