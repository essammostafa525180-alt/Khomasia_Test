using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.RequestAggregate
{
    public class RwDeliveredSerial : AggregateRootEntityBase<int>
    {
        public int? RwDeliveredBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public bool? Axsynced { get; set; }
        public RwDeliveredBatch? RwDeliveredBatchFkNavigation { get; set; }
        public InventoryItemLocationBatchSerial? SerialFkNavigation { get; set; }

        private List<InventoryItemReturnBatchSerial> _inventoryItemReturnBatchSerials = new List<InventoryItemReturnBatchSerial>();
        public IReadOnlyCollection<InventoryItemReturnBatchSerial> InventoryItemReturnBatchSerials => _inventoryItemReturnBatchSerials;

        public RwDeliveredSerial()
        {
        }

        public RwDeliveredSerial(int? rwDeliveredBatchFk, int? serialFk, bool? axsynced, bool isActive) : this()
        {
            RwDeliveredBatchFk = rwDeliveredBatchFk;
            SerialFk = serialFk;
            Axsynced = axsynced;
            IsActive = isActive;
        }

        public static RwDeliveredSerial Create(int? rwDeliveredBatchFk, int? serialFk, bool? axsynced, bool isActive)
        {

            return new RwDeliveredSerial(rwDeliveredBatchFk, serialFk, axsynced, isActive);
        }

        public void Update(int? rwDeliveredBatchFk, int? serialFk, bool? axsynced, bool isActive)
        {
            RwDeliveredBatchFk = rwDeliveredBatchFk;
            SerialFk = serialFk;
            Axsynced = axsynced;
            IsActive = isActive;
        }
    }
}
