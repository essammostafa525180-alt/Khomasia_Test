using Domain.Primitives;

namespace Domain.Aggregates.InventoryTransfereAggregate
{
    public class InventoryTransfereAttachment : AggregateRootEntityBase<int>
    {
        public int? InventoryTransfereFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public InventoryTransfere? InventoryTransfereFkNavigation { get; set; }

        public InventoryTransfereAttachment()
        {
        }

        public InventoryTransfereAttachment(int? inventoryTransfereFk, int? attachmentId, string? attachmentName, string? description, bool isActive) : this()
        {
            InventoryTransfereFk = inventoryTransfereFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }

        public static InventoryTransfereAttachment Create(int? inventoryTransfereFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {

            return new InventoryTransfereAttachment(inventoryTransfereFk, attachmentId, attachmentName, description, isActive);
        }

        public void Update(int? inventoryTransfereFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {
            InventoryTransfereFk = inventoryTransfereFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }
    }
}
