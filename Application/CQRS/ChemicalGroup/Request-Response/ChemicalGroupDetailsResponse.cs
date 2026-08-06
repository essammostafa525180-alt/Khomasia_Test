namespace Application.CQRS.ChemicalGroup;

public record ChemicalGroupDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);