namespace Application.CQRS.AssetAttachment;

public record AssetAttachmentDetailsResponse
(
    int Id,
    bool IsActive,
    bool IsDeleted,
    int? AssetFk,
    int? AttachmentId,
    string? AttachmentName,
    string? Description
);