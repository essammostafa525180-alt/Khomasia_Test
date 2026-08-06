namespace Application.CQRS.DaysOfWeek;

public record DaysOfWeekDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);