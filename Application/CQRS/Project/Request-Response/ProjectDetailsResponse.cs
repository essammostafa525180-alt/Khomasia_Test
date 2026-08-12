namespace Application.CQRS.Project;

public record ProjectDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name,
    string? NameAr,
    int? CompanyFk,
    int? StoreFk,
    int? CustomerFk
);