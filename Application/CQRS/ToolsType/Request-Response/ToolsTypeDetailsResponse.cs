namespace Application.CQRS.ToolsType;

public record ToolsTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AssetGroupFk,
    string? Name,
    string? NameAr
);