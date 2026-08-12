namespace Application.CQRS.StoreKeeper;

public record StoreKeeperDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? StoreFk,
    int? StoreKeeperFk
);