namespace Application.CQRS.ViewRequestStatus;

public record ViewRequestStatusDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int PurchaseRequestFk,
    decimal? TotalRequestedQuantity,
    decimal? TotalOrderedQuantity,
    int RequestOrderStatusId
);