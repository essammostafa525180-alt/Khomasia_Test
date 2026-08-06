using Domain.Aggregates.VendorAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemVendor : AggregateRootEntityBase<int>
    {
        public long? InventoryItemFk { get; set; }
        public int? VendorFk { get; set; }
        public int? VendorOrder { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public Vendor? VendorFkNavigation { get; set; }

        public InventoryItemVendor()
        {
        }

        public InventoryItemVendor(long? inventoryItemFk, int? vendorFk, int? vendorOrder, bool isActive) : this()
        {
            InventoryItemFk = inventoryItemFk;
            VendorFk = vendorFk;
            VendorOrder = vendorOrder;
            IsActive = isActive;
        }

        public static InventoryItemVendor Create(long? inventoryItemFk, int? vendorFk, int? vendorOrder, bool isActive)
        {

            return new InventoryItemVendor(inventoryItemFk, vendorFk, vendorOrder, isActive);
        }

        public void Update(long? inventoryItemFk, int? vendorFk, int? vendorOrder, bool isActive)
        {
            InventoryItemFk = inventoryItemFk;
            VendorFk = vendorFk;
            VendorOrder = vendorOrder;
            IsActive = isActive;
        }
    }
}
