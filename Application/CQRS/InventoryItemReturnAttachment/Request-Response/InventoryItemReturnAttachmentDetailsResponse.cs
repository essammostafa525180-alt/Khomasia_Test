namespace Application.CQRS.InventoryItemReturnAttachment;

public record InventoryItemReturnAttachmentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventoryItemReturnFk,
    int? AttachmentId,
    string? AttachmentName,
    string? Description
);