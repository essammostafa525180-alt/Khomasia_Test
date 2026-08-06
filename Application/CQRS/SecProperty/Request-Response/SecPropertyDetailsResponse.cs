namespace Application.CQRS.SecProperty;

public record SecPropertyDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Type,
    string? Name,
    int? SecModuleId,
    string? NameAr
);