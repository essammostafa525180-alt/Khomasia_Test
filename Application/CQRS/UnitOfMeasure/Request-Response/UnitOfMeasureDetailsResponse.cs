namespace Application.CQRS.UnitOfMeasure;

public record UnitOfMeasureDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    bool? Axsynced
);