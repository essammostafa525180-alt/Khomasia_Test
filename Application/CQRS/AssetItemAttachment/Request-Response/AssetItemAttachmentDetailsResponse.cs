namespace Application.CQRS.AssetItemAttachment;

public record AssetItemAttachmentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AssetItemFk,
    int? AttachmentId,
    string? AttachmentName,
    string? Description
);