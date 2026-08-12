namespace Application.CQRS.Shelf;

public record ShelfDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int IsleFk,
    string? Code,
    string? Name,
    int Level,
    decimal? MaxWeight
);
