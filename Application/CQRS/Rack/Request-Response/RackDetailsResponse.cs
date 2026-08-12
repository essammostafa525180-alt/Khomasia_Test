namespace Application.CQRS.Rack;

public record RackDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int ShelfFk,
    string? Code,
    string? Name,
    decimal? Capacity,
    decimal? MaxWeight
);
