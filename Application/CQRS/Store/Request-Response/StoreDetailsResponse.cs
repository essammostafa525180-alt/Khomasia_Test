namespace Application.CQRS.Store;

public record StoreDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);