namespace Application.CQRS.ServiceType;

public record ServiceTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr
);