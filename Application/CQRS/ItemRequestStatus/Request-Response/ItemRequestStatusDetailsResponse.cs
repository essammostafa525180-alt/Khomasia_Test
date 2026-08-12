namespace Application.CQRS.ItemRequestStatus;

public record ItemRequestStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);