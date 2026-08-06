namespace Application.CQRS.SecConfiguration;

public record SecConfigurationDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Key,
    string? Value
);