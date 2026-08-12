using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.VendorReturnAggregate
{
    public class VendorReturnSerial : AggregateRootEntityBase<int>
    {
        public int? VendorReturnFk { get; set; }
        public int? VendorReturnDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public InventoryItemSerial? InventoryItemSerialFkNavigation { get; set; }
        public VendorReturnDetail? VendorReturnDetailFkNavigation { get; set; }
        public VendorReturn? VendorReturnFkNavigation { get; set; }

        public VendorReturnSerial()
        {
        }

        public VendorReturnSerial(int? vendorReturnFk, int? vendorReturnDetailFk, int? inventoryItemSerialFk, bool isActive) : this()
        {
            VendorReturnFk = vendorReturnFk;
            VendorReturnDetailFk = vendorReturnDetailFk;
            InventoryItemSerialFk = inventoryItemSerialFk;
            IsActive = isActive;
        }

        public static VendorReturnSerial Create(int? vendorReturnFk, int? vendorReturnDetailFk, int? inventoryItemSerialFk, bool isActive)
        {

            return new VendorReturnSerial(vendorReturnFk, vendorReturnDetailFk, inventoryItemSerialFk, isActive);
        }

        public void Update(int? vendorReturnFk, int? vendorReturnDetailFk, int? inventoryItemSerialFk, bool isActive)
        {
            VendorReturnFk = vendorReturnFk;
            VendorReturnDetailFk = vendorReturnDetailFk;
            InventoryItemSerialFk = inventoryItemSerialFk;
            IsActive = isActive;
        }
    }
}
