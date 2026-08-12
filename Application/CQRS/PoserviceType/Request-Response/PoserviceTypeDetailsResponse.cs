namespace Application.CQRS.PoserviceType;

public record PoserviceTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);