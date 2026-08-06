namespace Application.CQRS.VendorOrderAttachment;

public record VendorOrderAttachmentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderFk,
    int? AttachmentId,
    string? AttachmentName,
    string? Description
);