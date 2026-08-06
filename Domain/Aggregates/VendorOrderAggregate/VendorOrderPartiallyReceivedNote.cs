using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderPartiallyReceivedNote : AggregateRootEntityBase<int>
    {
        public int? VendorOrderDetailFk { get; set; }
        public int? PartiallyReceivedReasonFk { get; set; }
        public decimal? CurrentReceivedQuantity { get; set; }
        public string? Notes { get; set; }
        public VendorOrderDetail? VendorOrderDetailFkNavigation { get; set; }

        public VendorOrderPartiallyReceivedNote()
        {
        }

        public VendorOrderPartiallyReceivedNote(int? vendorOrderDetailFk, int? partiallyReceivedReasonFk, decimal? currentReceivedQuantity, string? notes, bool isActive) : this()
        {
            VendorOrderDetailFk = vendorOrderDetailFk;
            PartiallyReceivedReasonFk = partiallyReceivedReasonFk;
            CurrentReceivedQuantity = currentReceivedQuantity;
            Notes = notes;
            IsActive = isActive;
        }

        public static VendorOrderPartiallyReceivedNote Create(int? vendorOrderDetailFk, int? partiallyReceivedReasonFk, decimal? currentReceivedQuantity, string? notes, bool isActive)
        {

            return new VendorOrderPartiallyReceivedNote(vendorOrderDetailFk, partiallyReceivedReasonFk, currentReceivedQuantity, notes, isActive);
        }

        public void Update(int? vendorOrderDetailFk, int? partiallyReceivedReasonFk, decimal? currentReceivedQuantity, string? notes, bool isActive)
        {
            VendorOrderDetailFk = vendorOrderDetailFk;
            PartiallyReceivedReasonFk = partiallyReceivedReasonFk;
            CurrentReceivedQuantity = currentReceivedQuantity;
            Notes = notes;
            IsActive = isActive;
        }
    }
}
