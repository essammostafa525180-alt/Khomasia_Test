using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderReceiveDetail : AggregateRootEntityBase<int>
    {
        public int? VendorOrderReceiveFk { get; set; }
        public int? VendorOrderQualityDetailFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? ReceivedQuantity { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public int? FromSerialize { get; set; }
        public int? ToSerialize { get; set; }
        public string? Notes { get; set; }
        public string? PartNo { get; set; }
        public string? ManufacturerCountry { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public VendorOrderQualityDetail? VendorOrderQualityDetailFkNavigation { get; set; }
        public VendorOrderReceive? VendorOrderReceiveFkNavigation { get; set; }

        private List<VendorOrderReceiveDetailBatch> _vendorOrderReceiveDetailBatches = new List<VendorOrderReceiveDetailBatch>();
        public IReadOnlyCollection<VendorOrderReceiveDetailBatch> VendorOrderReceiveDetailBatches => _vendorOrderReceiveDetailBatches;

        private List<VendorOrderReceiveSerial> _vendorOrderReceiveSerials = new List<VendorOrderReceiveSerial>();
        public IReadOnlyCollection<VendorOrderReceiveSerial> VendorOrderReceiveSerials => _vendorOrderReceiveSerials;

        public VendorOrderReceiveDetail()
        {
        }

        public VendorOrderReceiveDetail(int? vendorOrderReceiveFk, int? vendorOrderQualityDetailFk, long? inventoryItemFk, decimal? receivedQuantity, decimal? returnedQuantity, int? fromSerialize, int? toSerialize, string? notes, string? partNo, string? manufacturerCountry, bool isActive) : this()
        {
            VendorOrderReceiveFk = vendorOrderReceiveFk;
            VendorOrderQualityDetailFk = vendorOrderQualityDetailFk;
            InventoryItemFk = inventoryItemFk;
            ReceivedQuantity = receivedQuantity;
            ReturnedQuantity = returnedQuantity;
            FromSerialize = fromSerialize;
            ToSerialize = toSerialize;
            Notes = notes;
            PartNo = partNo;
            ManufacturerCountry = manufacturerCountry;
            IsActive = isActive;
        }

        public static VendorOrderReceiveDetail Create(int? vendorOrderReceiveFk, int? vendorOrderQualityDetailFk, long? inventoryItemFk, decimal? receivedQuantity, decimal? returnedQuantity, int? fromSerialize, int? toSerialize, string? notes, string? partNo, string? manufacturerCountry, bool isActive)
        {

            return new VendorOrderReceiveDetail(vendorOrderReceiveFk, vendorOrderQualityDetailFk, inventoryItemFk, receivedQuantity, returnedQuantity, fromSerialize, toSerialize, notes, partNo, manufacturerCountry, isActive);
        }

        public void Update(int? vendorOrderReceiveFk, int? vendorOrderQualityDetailFk, long? inventoryItemFk, decimal? receivedQuantity, decimal? returnedQuantity, int? fromSerialize, int? toSerialize, string? notes, string? partNo, string? manufacturerCountry, bool isActive)
        {
            VendorOrderReceiveFk = vendorOrderReceiveFk;
            VendorOrderQualityDetailFk = vendorOrderQualityDetailFk;
            InventoryItemFk = inventoryItemFk;
            ReceivedQuantity = receivedQuantity;
            ReturnedQuantity = returnedQuantity;
            FromSerialize = fromSerialize;
            ToSerialize = toSerialize;
            Notes = notes;
            PartNo = partNo;
            ManufacturerCountry = manufacturerCountry;
            IsActive = isActive;
        }
    }
}
