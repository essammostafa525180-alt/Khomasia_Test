using Domain.Primitives;

namespace Domain.Aggregates.VendorReturnAggregate
{
    public class VendorReturnAttachment : AggregateRootEntityBase<int>
    {
        public int? VendorReturnFk { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentName { get; set; }
        public string? Description { get; set; }
        public VendorReturn? VendorReturnFkNavigation { get; set; }

        public VendorReturnAttachment()
        {
        }

        public VendorReturnAttachment(int? vendorReturnFk, int? attachmentId, string? attachmentName, string? description, bool isActive) : this()
        {
            VendorReturnFk = vendorReturnFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }

        public static VendorReturnAttachment Create(int? vendorReturnFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {

            return new VendorReturnAttachment(vendorReturnFk, attachmentId, attachmentName, description, isActive);
        }

        public void Update(int? vendorReturnFk, int? attachmentId, string? attachmentName, string? description, bool isActive)
        {
            VendorReturnFk = vendorReturnFk;
            AttachmentId = attachmentId;
            AttachmentName = attachmentName;
            Description = description;
            IsActive = isActive;
        }
    }
}
