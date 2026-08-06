using Domain.Primitives;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetAttachment : AggregateRootEntityBase<int>
    {
        public int? AssetFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public Asset? AssetFkNavigation { get; set; }

        public AssetAttachment()
        {
        }

        public AssetAttachment(int? assetFk, int? attachmentId, string? attachmentName, string? description, bool isActive) : this()
        {
            AssetFk = assetFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }

        public static AssetAttachment Create(int? assetFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {

            return new AssetAttachment(assetFk, attachmentId, attachmentName, description, isActive);
        }

        public void Update(int? assetFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {
            AssetFk = assetFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }
    }
}
