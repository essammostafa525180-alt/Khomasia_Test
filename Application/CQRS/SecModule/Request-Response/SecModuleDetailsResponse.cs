namespace Application.CQRS.SecModule;

public record SecModuleDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr,
    string? ModuleName
);