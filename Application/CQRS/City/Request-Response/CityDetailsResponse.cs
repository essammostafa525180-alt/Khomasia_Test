namespace Application.CQRS.City;

public record CityDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    int? StateFk,
    int? RelatedProjectFk,
    bool? Axsynced
);