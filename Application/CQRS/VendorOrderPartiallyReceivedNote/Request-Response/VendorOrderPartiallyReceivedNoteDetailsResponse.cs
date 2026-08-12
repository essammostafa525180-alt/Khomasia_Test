namespace Application.CQRS.VendorOrderPartiallyReceivedNote;

public record VendorOrderPartiallyReceivedNoteDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderDetailFk,
    int? PartiallyReceivedReasonFk,
    decimal? CurrentReceivedQuantity,
    string? Notes
);