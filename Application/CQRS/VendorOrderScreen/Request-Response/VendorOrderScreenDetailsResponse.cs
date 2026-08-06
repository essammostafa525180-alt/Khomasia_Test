namespace Application.CQRS.VendorOrderScreen;

public record VendorOrderScreenDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Code,
    string? Name
);