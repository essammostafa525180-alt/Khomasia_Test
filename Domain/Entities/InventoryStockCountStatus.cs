using Domain.Aggregates.InventoryStockCountAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class InventoryStockCountStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryStockCount> _inventoryStockCounts = new List<InventoryStockCount>();
        public IReadOnlyCollection<InventoryStockCount> InventoryStockCounts => _inventoryStockCounts;

        private InventoryStockCountStatus()
        {
        }

        public InventoryStockCountStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static InventoryStockCountStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new InventoryStockCountStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
