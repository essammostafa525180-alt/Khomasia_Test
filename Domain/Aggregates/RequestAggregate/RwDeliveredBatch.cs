using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.RequestAggregate
{
    public class RwDeliveredBatch : AggregateRootEntityBase<int>
    {
        public int? RequestWdfk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public decimal? DeliveredQuantity { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public int? BatchFk { get; set; }
        public bool? Axsynced { get; set; }
        public InventoryItemLocationBatch? BatchFkNavigation { get; set; }
        public InventroyItemRequestWithdrawDetail? RequestWdfkNavigation { get; set; }

        private List<InventoryItemReturnBatch> _inventoryItemReturnBatches = new List<InventoryItemReturnBatch>();
        public IReadOnlyCollection<InventoryItemReturnBatch> InventoryItemReturnBatches => _inventoryItemReturnBatches;

        private List<RwDeliveredSerial> _rwDeliveredSerials = new List<RwDeliveredSerial>();
        public IReadOnlyCollection<RwDeliveredSerial> RwDeliveredSerials => _rwDeliveredSerials;

        public RwDeliveredBatch()
        {
        }

        public RwDeliveredBatch(int? requestWdfk, decimal? returnedQuantity, decimal? deliveredQuantity, DateTime? deliveredDate, int? batchFk, bool? axsynced, bool isActive) : this()
        {
            RequestWdfk = requestWdfk;
            ReturnedQuantity = returnedQuantity;
            DeliveredQuantity = deliveredQuantity;
            DeliveredDate = deliveredDate;
            BatchFk = batchFk;
            Axsynced = axsynced;
            IsActive = isActive;
        }

        public static RwDeliveredBatch Create(int? requestWdfk, decimal? returnedQuantity, decimal? deliveredQuantity, DateTime? deliveredDate, int? batchFk, bool? axsynced, bool isActive)
        {

            return new RwDeliveredBatch(requestWdfk, returnedQuantity, deliveredQuantity, deliveredDate, batchFk, axsynced, isActive);
        }

        public void Update(int? requestWdfk, decimal? returnedQuantity, decimal? deliveredQuantity, DateTime? deliveredDate, int? batchFk, bool? axsynced, bool isActive)
        {
            RequestWdfk = requestWdfk;
            ReturnedQuantity = returnedQuantity;
            DeliveredQuantity = deliveredQuantity;
            DeliveredDate = deliveredDate;
            BatchFk = batchFk;
            Axsynced = axsynced;
            IsActive = isActive;
        }
    }
}
