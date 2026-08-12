namespace Application.CQRS.AssetCountDetail;

public record AssetCountDetailDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AssetCountFk,
    int? AssetFk,
    int? AssetCountStatusFk,
    string? Notes
);