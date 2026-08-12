using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class PurchaseOrderServiceAttachment : AggregateRootEntityBase<int>
    {
        public int? PurchaseOrderServiceFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public PurchaseOrderService? PurchaseOrderServiceFkNavigation { get; set; }

        public PurchaseOrderServiceAttachment()
        {
        }

        public PurchaseOrderServiceAttachment(int? purchaseOrderServiceFk, int? attachmentId, string? attachmentName, string? description, bool isActive) : this()
        {
            PurchaseOrderServiceFk = purchaseOrderServiceFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }

        public static PurchaseOrderServiceAttachment Create(int? purchaseOrderServiceFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {

            return new PurchaseOrderServiceAttachment(purchaseOrderServiceFk, attachmentId, attachmentName, description, isActive);
        }

        public void Update(int? purchaseOrderServiceFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {
            PurchaseOrderServiceFk = purchaseOrderServiceFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }
    }
}
