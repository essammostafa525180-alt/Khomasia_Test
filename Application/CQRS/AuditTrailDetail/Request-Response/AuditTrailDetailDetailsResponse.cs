namespace Application.CQRS.AuditTrailDetail;

public record AuditTrailDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AuditTrailId,
    string? Property,
    string? OldValue,
    string? NewValue,
    string? ReferenceTable
);