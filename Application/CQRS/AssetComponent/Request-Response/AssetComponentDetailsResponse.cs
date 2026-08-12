namespace Application.CQRS.AssetComponent;

public record AssetComponentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AssetFk,
    int? ComponentFk
);