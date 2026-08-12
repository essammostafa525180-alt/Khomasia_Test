using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderQualityDetail : AggregateRootEntityBase<int>
    {
        public int? VendorOrderQualityFk { get; set; }
        public int? VendorOrderDetailFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? ReceivedQuantity { get; set; }
        public decimal? LandedCost { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public VendorOrderDetail? VendorOrderDetailFkNavigation { get; set; }
        public VendorOrderQuality? VendorOrderQualityFkNavigation { get; set; }

        private List<VendorOrderQualityDetailBatch> _vendorOrderQualityDetailBatches = new List<VendorOrderQualityDetailBatch>();
        public IReadOnlyCollection<VendorOrderQualityDetailBatch> VendorOrderQualityDetailBatches => _vendorOrderQualityDetailBatches;

        private List<VendorOrderReceiveDetail> _vendorOrderReceiveDetails = new List<VendorOrderReceiveDetail>();
        public IReadOnlyCollection<VendorOrderReceiveDetail> VendorOrderReceiveDetails => _vendorOrderReceiveDetails;

        public VendorOrderQualityDetail()
        {
        }

        public VendorOrderQualityDetail(int? vendorOrderQualityFk, int? vendorOrderDetailFk, long? inventoryItemFk, decimal? receivedQuantity, decimal? landedCost, bool isActive) : this()
        {
            VendorOrderQualityFk = vendorOrderQualityFk;
            VendorOrderDetailFk = vendorOrderDetailFk;
            InventoryItemFk = inventoryItemFk;
            ReceivedQuantity = receivedQuantity;
            LandedCost = landedCost;
            IsActive = isActive;
        }

        public static VendorOrderQualityDetail Create(int? vendorOrderQualityFk, int? vendorOrderDetailFk, long? inventoryItemFk, decimal? receivedQuantity, decimal? landedCost, bool isActive)
        {

            return new VendorOrderQualityDetail(vendorOrderQualityFk, vendorOrderDetailFk, inventoryItemFk, receivedQuantity, landedCost, isActive);
        }

        public void Update(int? vendorOrderQualityFk, int? vendorOrderDetailFk, long? inventoryItemFk, decimal? receivedQuantity, decimal? landedCost, bool isActive)
        {
            VendorOrderQualityFk = vendorOrderQualityFk;
            VendorOrderDetailFk = vendorOrderDetailFk;
            InventoryItemFk = inventoryItemFk;
            ReceivedQuantity = receivedQuantity;
            LandedCost = landedCost;
            IsActive = isActive;
        }
    }
}
