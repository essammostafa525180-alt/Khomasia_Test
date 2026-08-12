namespace Application.CQRS.NotificationLog;

public record NotificationLogDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? CustomerId,
    int? TemplateId,
    int? LoyaltyLevelId
);