namespace Application.CQRS.VendorOrderReceiveAttachment;

public record VendorOrderReceiveAttachmentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderReceiveFk,
    int? AttachmentId,
    string? AttachmentName,
    string? Description
);