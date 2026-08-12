namespace Application.CQRS.VendorReturnAttachment;

public record VendorReturnAttachmentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorReturnFk,
    int? AttachmentId,
    string? AttachmentName,
    string? Description
);