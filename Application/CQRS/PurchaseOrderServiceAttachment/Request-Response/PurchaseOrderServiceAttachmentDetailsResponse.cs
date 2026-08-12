namespace Application.CQRS.PurchaseOrderServiceAttachment;

public record PurchaseOrderServiceAttachmentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? PurchaseOrderServiceFk,
    int? AttachmentId,
    string? AttachmentName,
    string? Description
);