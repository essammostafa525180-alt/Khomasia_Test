using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.InventoryTransfereAggregate
{
    public class InventoryTransfereSerial : AggregateRootEntityBase<int>
    {
        public int? InventoryTransfereFk { get; set; }
        public int? InventoryTransfereDetailFk { get; set; }
        public int? InventoryItemSerialFk { get; set; }
        public InventoryItemSerial? InventoryItemSerialFkNavigation { get; set; }
        public InventoryTransfereDetail? InventoryTransfereDetailFkNavigation { get; set; }
        public InventoryTransfere? InventoryTransfereFkNavigation { get; set; }

        public InventoryTransfereSerial()
        {
        }

        public InventoryTransfereSerial(int? inventoryTransfereFk, int? inventoryTransfereDetailFk, int? inventoryItemSerialFk, bool isActive) : this()
        {
            InventoryTransfereFk = inventoryTransfereFk;
            InventoryTransfereDetailFk = inventoryTransfereDetailFk;
            InventoryItemSerialFk = inventoryItemSerialFk;
            IsActive = isActive;
        }

        public static InventoryTransfereSerial Create(int? inventoryTransfereFk, int? inventoryTransfereDetailFk, int? inventoryItemSerialFk, bool isActive)
        {

            return new InventoryTransfereSerial(inventoryTransfereFk, inventoryTransfereDetailFk, inventoryItemSerialFk, isActive);
        }

        public void Update(int? inventoryTransfereFk, int? inventoryTransfereDetailFk, int? inventoryItemSerialFk, bool isActive)
        {
            InventoryTransfereFk = inventoryTransfereFk;
            InventoryTransfereDetailFk = inventoryTransfereDetailFk;
            InventoryItemSerialFk = inventoryItemSerialFk;
            IsActive = isActive;
        }
    }
}
