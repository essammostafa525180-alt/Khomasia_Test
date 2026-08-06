namespace Application.CQRS.SecViewAction;

public record SecViewActionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int ViewActionId,
    int? ViewId,
    string? Action,
    string? ActionNameAr,
    string? ActionName
);