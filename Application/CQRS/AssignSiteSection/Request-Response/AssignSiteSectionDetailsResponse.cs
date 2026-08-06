namespace Application.CQRS.AssignSiteSection;

public record AssignSiteSectionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);