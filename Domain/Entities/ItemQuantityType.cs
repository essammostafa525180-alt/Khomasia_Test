using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ItemQuantityType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryItemLocationDetail> _inventoryItemLocationDetails = new List<InventoryItemLocationDetail>();
        public IReadOnlyCollection<InventoryItemLocationDetail> InventoryItemLocationDetails => _inventoryItemLocationDetails;

        private List<InventoryItemLocation> _inventoryItemLocations = new List<InventoryItemLocation>();
        public IReadOnlyCollection<InventoryItemLocation> InventoryItemLocations => _inventoryItemLocations;

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems;

        private ItemQuantityType()
        {
        }

        public ItemQuantityType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static ItemQuantityType Create(string? name, string? nameAr, bool isActive)
        {

            return new ItemQuantityType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
