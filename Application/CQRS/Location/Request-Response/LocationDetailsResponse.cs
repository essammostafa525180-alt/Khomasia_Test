namespace Application.CQRS.Location;

public record LocationDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);