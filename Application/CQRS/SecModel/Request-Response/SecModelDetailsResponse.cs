namespace Application.CQRS.SecModel;

public record SecModelDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int ModelId,
    string? ModelName,
    string? ModelDisplayName,
    int? SecModuleId,
    string? ModelDisplayNameAr
);