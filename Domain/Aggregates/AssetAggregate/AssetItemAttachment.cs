using Domain.Primitives;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetItemAttachment : AggregateRootEntityBase<int>
    {
        public int? AssetItemFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public AssetItem? AssetItemFkNavigation { get; set; }

        public AssetItemAttachment()
        {
        }

        public AssetItemAttachment(int? assetItemFk, int? attachmentId, string? attachmentName, string? description, bool isActive) : this()
        {
            AssetItemFk = assetItemFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }

        public static AssetItemAttachment Create(int? assetItemFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {

            return new AssetItemAttachment(assetItemFk, attachmentId, attachmentName, description, isActive);
        }

        public void Update(int? assetItemFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {
            AssetItemFk = assetItemFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }
    }
}
