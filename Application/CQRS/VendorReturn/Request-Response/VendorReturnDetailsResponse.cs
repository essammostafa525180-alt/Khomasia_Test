namespace Application.CQRS.VendorReturn;

public record VendorReturnDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted
);