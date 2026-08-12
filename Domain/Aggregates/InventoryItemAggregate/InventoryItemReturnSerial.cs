using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemReturnSerial : AggregateRootEntityBase<int>
    {
        public int? InventoryItemReturnFk { get; set; }
        public int? InventoryItemReturnDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public InventoryItemReturnDetail? InventoryItemReturnDetailFkNavigation { get; set; }
        public InventoryItemReturn? InventoryItemReturnFkNavigation { get; set; }
        public InventoryItemSerial? InventoryItemSerialFkNavigation { get; set; }

        public InventoryItemReturnSerial()
        {
        }

        public InventoryItemReturnSerial(int? inventoryItemReturnFk, int? inventoryItemReturnDetailFk, int? inventoryItemSerialFk, bool isActive) : this()
        {
            InventoryItemReturnFk = inventoryItemReturnFk;
            InventoryItemReturnDetailFk = inventoryItemReturnDetailFk;
            InventoryItemSerialFk = inventoryItemSerialFk;
            IsActive = isActive;
        }

        public static InventoryItemReturnSerial Create(int? inventoryItemReturnFk, int? inventoryItemReturnDetailFk, int? inventoryItemSerialFk, bool isActive)
        {

            return new InventoryItemReturnSerial(inventoryItemReturnFk, inventoryItemReturnDetailFk, inventoryItemSerialFk, isActive);
        }

        public void Update(int? inventoryItemReturnFk, int? inventoryItemReturnDetailFk, int? inventoryItemSerialFk, bool isActive)
        {
            InventoryItemReturnFk = inventoryItemReturnFk;
            InventoryItemReturnDetailFk = inventoryItemReturnDetailFk;
            InventoryItemSerialFk = inventoryItemSerialFk;
            IsActive = isActive;
        }
    }
}
