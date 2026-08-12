using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ItemExpiryType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems;

        private ItemExpiryType()
        {
        }

        public ItemExpiryType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static ItemExpiryType Create(string? name, string? nameAr, bool isActive)
        {

            return new ItemExpiryType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
