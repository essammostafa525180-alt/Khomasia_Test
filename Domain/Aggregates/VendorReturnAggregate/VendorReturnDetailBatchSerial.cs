using Domain.Aggregates.VendorOrderAggregate;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.VendorReturnAggregate
{
    public class VendorReturnDetailBatchSerial : AggregateRootEntityBase<int>
    {
        public int? VendorReturnDetailBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public int? ReturnReasonFk { get; set; }
        public string? Notes { get; set; }
        public ReturnReason? ReturnReasonFkNavigation { get; set; }
        public VendorOrderReceiveDetailBatchSerial? SerialFkNavigation { get; set; }
        public VendorReturnDetailBatch? VendorReturnDetailBatchFkNavigation { get; set; }

        public VendorReturnDetailBatchSerial()
        {
        }

        public VendorReturnDetailBatchSerial(int? vendorReturnDetailBatchFk, int? serialFk, int? returnReasonFk, string? notes, bool isActive) : this()
        {
            VendorReturnDetailBatchFk = vendorReturnDetailBatchFk;
            SerialFk = serialFk;
            ReturnReasonFk = returnReasonFk;
            Notes = notes;
            IsActive = isActive;
        }

        public static VendorReturnDetailBatchSerial Create(int? vendorReturnDetailBatchFk, int? serialFk, int? returnReasonFk, string? notes, bool isActive)
        {

            return new VendorReturnDetailBatchSerial(vendorReturnDetailBatchFk, serialFk, returnReasonFk, notes, isActive);
        }

        public void Update(int? vendorReturnDetailBatchFk, int? serialFk, int? returnReasonFk, string? notes, bool isActive)
        {
            VendorReturnDetailBatchFk = vendorReturnDetailBatchFk;
            SerialFk = serialFk;
            ReturnReasonFk = returnReasonFk;
            Notes = notes;
            IsActive = isActive;
        }
    }
}
