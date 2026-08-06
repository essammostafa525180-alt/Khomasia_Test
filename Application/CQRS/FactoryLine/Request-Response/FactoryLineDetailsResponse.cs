namespace Application.CQRS.FactoryLine;

public record FactoryLineDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Description,
    int FactoryFk,
    string Name,
    string? NameAr,
    int? Capacity,
    string LineTypes
);