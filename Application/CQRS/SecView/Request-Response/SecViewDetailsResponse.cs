namespace Application.CQRS.SecView;

public record SecViewDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int ViewId,
    string? ViewName,
    string? ViewDisplayName,
    bool? IsVisibleToMenu,
    string? Url,
    int? SecModuleId,
    string? ViewDisplayNameAr,
    int? ParentId,
    int? Sequence
);