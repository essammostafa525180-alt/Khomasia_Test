using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemReturnDetail : AggregateRootEntityBase<int>
    {
        public int? InventoryItemReturnFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public int? ReturnReasonFk { get; set; }
        public string? Notes { get; set; }
        public decimal? ExternalReturnedQuantity { get; set; }
        public int? RequestWdfk { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public InventoryItemReturn? InventoryItemReturnFkNavigation { get; set; }
        public ReturnReason? ReturnReasonFkNavigation { get; set; }

        private List<InventoryItemReturnBatch> _inventoryItemReturnBatches = new List<InventoryItemReturnBatch>();
        public IReadOnlyCollection<InventoryItemReturnBatch> InventoryItemReturnBatches => _inventoryItemReturnBatches;

        private List<InventoryItemReturnSerial> _inventoryItemReturnSerials = new List<InventoryItemReturnSerial>();
        public IReadOnlyCollection<InventoryItemReturnSerial> InventoryItemReturnSerials => _inventoryItemReturnSerials;

        public InventoryItemReturnDetail()
        {
        }

        public InventoryItemReturnDetail(int? inventoryItemReturnFk, long? inventoryItemFk, decimal? returnedQuantity, int? returnReasonFk, string? notes, decimal? externalReturnedQuantity, int? requestWdfk, bool isActive) : this()
        {
            InventoryItemReturnFk = inventoryItemReturnFk;
            InventoryItemFk = inventoryItemFk;
            ReturnedQuantity = returnedQuantity;
            ReturnReasonFk = returnReasonFk;
            Notes = notes;
            ExternalReturnedQuantity = externalReturnedQuantity;
            RequestWdfk = requestWdfk;
            IsActive = isActive;
        }

        public static InventoryItemReturnDetail Create(int? inventoryItemReturnFk, long? inventoryItemFk, decimal? returnedQuantity, int? returnReasonFk, string? notes, decimal? externalReturnedQuantity, int? requestWdfk, bool isActive)
        {

            return new InventoryItemReturnDetail(inventoryItemReturnFk, inventoryItemFk, returnedQuantity, returnReasonFk, notes, externalReturnedQuantity, requestWdfk, isActive);
        }

        public void Update(int? inventoryItemReturnFk, long? inventoryItemFk, decimal? returnedQuantity, int? returnReasonFk, string? notes, decimal? externalReturnedQuantity, int? requestWdfk, bool isActive)
        {
            InventoryItemReturnFk = inventoryItemReturnFk;
            InventoryItemFk = inventoryItemFk;
            ReturnedQuantity = returnedQuantity;
            ReturnReasonFk = returnReasonFk;
            Notes = notes;
            ExternalReturnedQuantity = externalReturnedQuantity;
            RequestWdfk = requestWdfk;
            IsActive = isActive;
        }
    }
}
