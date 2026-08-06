namespace Application.CQRS.InventoryTransfereAttachment;

public record InventoryTransfereAttachmentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryTransfereFk,
    int? AttachmentId,
    string? AttachmentName,
    string? Description
);