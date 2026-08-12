using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderAttachment : AggregateRootEntityBase<int>
    {
        public int? VendorOrderFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public VendorOrder? VendorOrderFkNavigation { get; set; }

        public VendorOrderAttachment()
        {
        }

        public VendorOrderAttachment(int? vendorOrderFk, int? attachmentId, string? attachmentName, string? description, bool isActive) : this()
        {
            VendorOrderFk = vendorOrderFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }

        public static VendorOrderAttachment Create(int? vendorOrderFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {

            return new VendorOrderAttachment(vendorOrderFk, attachmentId, attachmentName, description, isActive);
        }

        public void Update(int? vendorOrderFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {
            VendorOrderFk = vendorOrderFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }
    }
}
