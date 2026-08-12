namespace Application.CQRS.EngineSize;

public record EngineSizeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name
);