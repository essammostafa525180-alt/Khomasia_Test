using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.InventoryTransfereAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Shelf : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? RackFk { get; private set; }
        public Rack? RackFkNavigation { get; private set; }

        private List<InventoryItemLocationBatch> _inventoryItemLocationBatches = new List<InventoryItemLocationBatch>();
        public IReadOnlyCollection<InventoryItemLocationBatch> InventoryItemLocationBatches => _inventoryItemLocationBatches;

        private List<InventoryTransfereDetailBatch> _inventoryTransfereDetailBatches = new List<InventoryTransfereDetailBatch>();
        public IReadOnlyCollection<InventoryTransfereDetailBatch> InventoryTransfereDetailBatches => _inventoryTransfereDetailBatches;

        private List<VendorOrderReceiveDetailBatch> _vendorOrderReceiveDetailBatches = new List<VendorOrderReceiveDetailBatch>();
        public IReadOnlyCollection<VendorOrderReceiveDetailBatch> VendorOrderReceiveDetailBatches => _vendorOrderReceiveDetailBatches;

        private Shelf()
        {
        }

        public Shelf(string? name, string? nameAr, int? rackFk, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            RackFk = rackFk;
            IsActive = isActive;
        }

        public static Shelf Create(string? name, string? nameAr, int? rackFk, bool isActive)
        {

            return new Shelf(name, nameAr, rackFk, isActive);
        }

        public void Update(string? name, string? nameAr, int? rackFk, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            RackFk = rackFk;
            IsActive = isActive;
        }
    }
}
