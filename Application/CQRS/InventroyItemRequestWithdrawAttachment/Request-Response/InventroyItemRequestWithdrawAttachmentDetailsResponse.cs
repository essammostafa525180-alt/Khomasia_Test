namespace Application.CQRS.InventroyItemRequestWithdrawAttachment;

public record InventroyItemRequestWithdrawAttachmentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? InventroyItemRequestWithdrawFk,
    int? AttachmentId,
    string? AttachmentName,
    string? Description
);