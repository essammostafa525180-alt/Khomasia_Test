namespace Application.CQRS.AssetMoveType;

public record AssetMoveTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);