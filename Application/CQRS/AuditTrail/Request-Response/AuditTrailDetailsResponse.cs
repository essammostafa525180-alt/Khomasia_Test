namespace Application.CQRS.AuditTrail;

public record AuditTrailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? TableName,
    string? Action,
    DateTime? ExecutedAt,
    int? UserId,
    int? EntityId,
    string? ClientComputerName,
    string? ClientIp,
    int? ParentAuditTrailId
);