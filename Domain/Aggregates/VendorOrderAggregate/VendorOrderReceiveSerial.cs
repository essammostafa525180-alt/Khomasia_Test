using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderReceiveSerial : AggregateRootEntityBase<int>
    {
        public int? VendorOrderReceiveFk { get; set; }
        public int? VendorOrderReceiveDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public InventoryItemSerial? InventoryItemSerialFkNavigation { get; set; }
        public VendorOrderReceiveDetail? VendorOrderReceiveDetailFkNavigation { get; set; }
        public VendorOrderReceive? VendorOrderReceiveFkNavigation { get; set; }

        public VendorOrderReceiveSerial()
        {
        }

        public VendorOrderReceiveSerial(int? vendorOrderReceiveFk, int? vendorOrderReceiveDetailFk, int? inventoryItemSerialFk, bool isActive) : this()
        {
            VendorOrderReceiveFk = vendorOrderReceiveFk;
            VendorOrderReceiveDetailFk = vendorOrderReceiveDetailFk;
            InventoryItemSerialFk = inventoryItemSerialFk;
            IsActive = isActive;
        }

        public static VendorOrderReceiveSerial Create(int? vendorOrderReceiveFk, int? vendorOrderReceiveDetailFk, int? inventoryItemSerialFk, bool isActive)
        {

            return new VendorOrderReceiveSerial(vendorOrderReceiveFk, vendorOrderReceiveDetailFk, inventoryItemSerialFk, isActive);
        }

        public void Update(int? vendorOrderReceiveFk, int? vendorOrderReceiveDetailFk, int? inventoryItemSerialFk, bool isActive)
        {
            VendorOrderReceiveFk = vendorOrderReceiveFk;
            VendorOrderReceiveDetailFk = vendorOrderReceiveDetailFk;
            InventoryItemSerialFk = inventoryItemSerialFk;
            IsActive = isActive;
        }
    }
}
