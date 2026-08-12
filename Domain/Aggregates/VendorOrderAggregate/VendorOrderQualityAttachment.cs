using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderQualityAttachment : AggregateRootEntityBase<int>
    {
        public int? VendorOrderQualityFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public VendorOrderQuality? VendorOrderQualityFkNavigation { get; set; }

        public VendorOrderQualityAttachment()
        {
        }

        public VendorOrderQualityAttachment(int? vendorOrderQualityFk, int? attachmentId, string? attachmentName, string? description, bool isActive) : this()
        {
            VendorOrderQualityFk = vendorOrderQualityFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }

        public static VendorOrderQualityAttachment Create(int? vendorOrderQualityFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {

            return new VendorOrderQualityAttachment(vendorOrderQualityFk, attachmentId, attachmentName, description, isActive);
        }

        public void Update(int? vendorOrderQualityFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {
            VendorOrderQualityFk = vendorOrderQualityFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }
    }
}
