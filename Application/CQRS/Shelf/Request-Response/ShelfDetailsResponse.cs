namespace Application.CQRS.Shelf;

public record ShelfDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr,
    int? RackFk
);