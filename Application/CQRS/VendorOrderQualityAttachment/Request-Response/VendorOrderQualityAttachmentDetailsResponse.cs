namespace Application.CQRS.VendorOrderQualityAttachment;

public record VendorOrderQualityAttachmentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? VendorOrderQualityFk,
    int? AttachmentId,
    string? AttachmentName,
    string? Description
);