namespace Application.CQRS.ReturnStatus;

public record ReturnStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);