namespace Application.CQRS.OrderLineItemStatus;

public record OrderLineItemStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    string? Name,
    string? NameAr
);