namespace Application.CQRS.Rack;

public record RackDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr,
    int? IsleFk
);