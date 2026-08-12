namespace Application.CQRS.TransferStatus;

public record TransferStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);