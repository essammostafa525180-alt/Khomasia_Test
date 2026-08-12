using Domain.Aggregates.VendorReturnAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderReceiveDetailBatchSerial : AggregateRootEntityBase<int>
    {
        public int? VendorOrderReceiveDetailBatchFk { get; set; }
        public string? SerialNumber { get; set; }
        public VendorOrderReceiveDetailBatch? VendorOrderReceiveDetailBatchFkNavigation { get; set; }

        private List<VendorReturnDetailBatchSerial> _vendorReturnDetailBatchSerials = new List<VendorReturnDetailBatchSerial>();
        public IReadOnlyCollection<VendorReturnDetailBatchSerial> VendorReturnDetailBatchSerials => _vendorReturnDetailBatchSerials;

        public VendorOrderReceiveDetailBatchSerial()
        {
        }

        public VendorOrderReceiveDetailBatchSerial(int? vendorOrderReceiveDetailBatchFk, string? serialNumber, bool isActive) : this()
        {
            VendorOrderReceiveDetailBatchFk = vendorOrderReceiveDetailBatchFk;
            SerialNumber = serialNumber;
            IsActive = isActive;
        }

        public static VendorOrderReceiveDetailBatchSerial Create(int? vendorOrderReceiveDetailBatchFk, string? serialNumber, bool isActive)
        {

            return new VendorOrderReceiveDetailBatchSerial(vendorOrderReceiveDetailBatchFk, serialNumber, isActive);
        }

        public void Update(int? vendorOrderReceiveDetailBatchFk, string? serialNumber, bool isActive)
        {
            VendorOrderReceiveDetailBatchFk = vendorOrderReceiveDetailBatchFk;
            SerialNumber = serialNumber;
            IsActive = isActive;
        }
    }
}
