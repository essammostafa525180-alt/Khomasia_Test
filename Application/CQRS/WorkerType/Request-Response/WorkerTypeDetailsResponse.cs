namespace Application.CQRS.WorkerType;

public record WorkerTypeDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);