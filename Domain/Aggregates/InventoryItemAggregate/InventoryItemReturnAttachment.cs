using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemReturnAttachment : AggregateRootEntityBase<int>
    {
        public int? InventoryItemReturnFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public InventoryItemReturn? InventoryItemReturnFkNavigation { get; set; }

        public InventoryItemReturnAttachment()
        {
        }

        public InventoryItemReturnAttachment(int? inventoryItemReturnFk, int? attachmentId, string? attachmentName, string? description, bool isActive) : this()
        {
            InventoryItemReturnFk = inventoryItemReturnFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }

        public static InventoryItemReturnAttachment Create(int? inventoryItemReturnFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {

            return new InventoryItemReturnAttachment(inventoryItemReturnFk, attachmentId, attachmentName, description, isActive);
        }

        public void Update(int? inventoryItemReturnFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {
            InventoryItemReturnFk = inventoryItemReturnFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }
    }
}
