namespace Application.CQRS.TransferReason;

public record TransferReasonDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);