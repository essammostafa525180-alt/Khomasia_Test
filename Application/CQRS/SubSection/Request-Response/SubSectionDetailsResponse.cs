namespace Application.CQRS.SubSection;

public record SubSectionDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    int? SectionFk
);