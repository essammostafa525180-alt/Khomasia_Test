namespace Application.CQRS.PaymentTerm;

public record PaymentTermDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);