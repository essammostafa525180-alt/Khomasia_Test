namespace Application.CQRS.SysKeyValue;

public record SysKeyValueDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? SysKey,
    string? SysValue,
    string? Description,
    string? DescriptionAr
);