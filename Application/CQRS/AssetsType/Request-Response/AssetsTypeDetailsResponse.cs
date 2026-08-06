namespace Application.CQRS.AssetsType;

public record AssetsTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);