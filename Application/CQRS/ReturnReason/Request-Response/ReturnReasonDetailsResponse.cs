namespace Application.CQRS.ReturnReason;

public record ReturnReasonDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr,
    int? IntegrationId
);