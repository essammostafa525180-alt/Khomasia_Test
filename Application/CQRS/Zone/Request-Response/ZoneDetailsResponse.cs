namespace Application.CQRS.Zone;

public record ZoneDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);