namespace Application.CQRS.Manufacture;

public record ManufactureDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);