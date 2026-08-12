namespace Application.CQRS.WsLastSyncTable;

public record WsLastSyncTableDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Key,
    string? Value
);