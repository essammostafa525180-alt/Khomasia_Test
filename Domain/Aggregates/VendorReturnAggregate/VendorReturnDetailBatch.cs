using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorReturnAggregate
{
    public class VendorReturnDetailBatch : AggregateRootEntityBase<int>
    {
        public int? VendorReturnDetailFk { get; set; }
        public decimal? Quantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public string? Notes { get; set; }
        public int? BatchFk { get; set; }
        public int? VendorOrderReceiveDetailBatchFk { get; set; }
        public ReturnReason? ReturnReasonFkNavigation { get; set; }

        private List<VendorReturnDetailBatchSerial> _vendorReturnDetailBatchSerials = new List<VendorReturnDetailBatchSerial>();
        public IReadOnlyCollection<VendorReturnDetailBatchSerial> VendorReturnDetailBatchSerials => _vendorReturnDetailBatchSerials;

        public VendorReturnDetailBatch()
        {
        }

        public VendorReturnDetailBatch(int? vendorReturnDetailFk, decimal? quantity, int? returnReasonFk, string? notes, int? batchFk, int? vendorOrderReceiveDetailBatchFk, bool isActive) : this()
        {
            VendorReturnDetailFk = vendorReturnDetailFk;
            Quantity = quantity;
            ReturnReasonFk = returnReasonFk;
            Notes = notes;
            BatchFk = batchFk;
            VendorOrderReceiveDetailBatchFk = vendorOrderReceiveDetailBatchFk;
            IsActive = isActive;
        }

        public static VendorReturnDetailBatch Create(int? vendorReturnDetailFk, decimal? quantity, int? returnReasonFk, string? notes, int? batchFk, int? vendorOrderReceiveDetailBatchFk, bool isActive)
        {

            return new VendorReturnDetailBatch(vendorReturnDetailFk, quantity, returnReasonFk, notes, batchFk, vendorOrderReceiveDetailBatchFk, isActive);
        }

        public void Update(int? vendorReturnDetailFk, decimal? quantity, int? returnReasonFk, string? notes, int? batchFk, int? vendorOrderReceiveDetailBatchFk, bool isActive)
        {
            VendorReturnDetailFk = vendorReturnDetailFk;
            Quantity = quantity;
            ReturnReasonFk = returnReasonFk;
            Notes = notes;
            BatchFk = batchFk;
            VendorOrderReceiveDetailBatchFk = vendorOrderReceiveDetailBatchFk;
            IsActive = isActive;
        }
    }
}
