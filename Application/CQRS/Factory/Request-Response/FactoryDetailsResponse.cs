namespace Application.CQRS.Factory;

public record FactoryDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Description,
    string? Address,
    string Name,
    string? NameAr
);