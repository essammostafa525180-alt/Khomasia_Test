using Domain.Primitives;

namespace Domain.Aggregates.RequestAggregate
{
    public class InventroyItemRequestWithdrawAttachment : AggregateRootEntityBase<int>
    {
        public int? InventroyItemRequestWithdrawFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public InventroyItemRequestWithdraw? InventroyItemRequestWithdrawFkNavigation { get; set; }

        public InventroyItemRequestWithdrawAttachment()
        {
        }

        public InventroyItemRequestWithdrawAttachment(int? inventroyItemRequestWithdrawFk, int? attachmentId, string? attachmentName, string? description, bool isActive) : this()
        {
            InventroyItemRequestWithdrawFk = inventroyItemRequestWithdrawFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }

        public static InventroyItemRequestWithdrawAttachment Create(int? inventroyItemRequestWithdrawFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {

            return new InventroyItemRequestWithdrawAttachment(inventroyItemRequestWithdrawFk, attachmentId, attachmentName, description, isActive);
        }

        public void Update(int? inventroyItemRequestWithdrawFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {
            InventroyItemRequestWithdrawFk = inventroyItemRequestWithdrawFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }
    }
}
