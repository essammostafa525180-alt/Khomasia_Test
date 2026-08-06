namespace Application.CQRS.Pdamodel;

public record PdamodelDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);