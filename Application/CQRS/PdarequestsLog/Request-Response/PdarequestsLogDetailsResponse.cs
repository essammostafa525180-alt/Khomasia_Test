namespace Application.CQRS.PdarequestsLog;

public record PdarequestsLogDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? RequestFk,
    int? AssignedToFk,
    bool? IsChanged,
    string? PdarequestType
);