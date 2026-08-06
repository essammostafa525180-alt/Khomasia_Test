using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderReceiveAttachment : AggregateRootEntityBase<int>
    {
        public int? VendorOrderReceiveFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public VendorOrderReceive? VendorOrderReceiveFkNavigation { get; set; }

        public VendorOrderReceiveAttachment()
        {
        }

        public VendorOrderReceiveAttachment(int? vendorOrderReceiveFk, int? attachmentId, string? attachmentName, string? description, bool isActive) : this()
        {
            VendorOrderReceiveFk = vendorOrderReceiveFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }

        public static VendorOrderReceiveAttachment Create(int? vendorOrderReceiveFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {

            return new VendorOrderReceiveAttachment(vendorOrderReceiveFk, attachmentId, attachmentName, description, isActive);
        }

        public void Update(int? vendorOrderReceiveFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {
            VendorOrderReceiveFk = vendorOrderReceiveFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }
    }
}
