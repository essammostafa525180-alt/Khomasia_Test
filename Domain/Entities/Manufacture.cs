using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Manufacture : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<Asset> _assets = new List<Asset>();
        public IReadOnlyCollection<Asset> Assets => _assets;

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems;

        private Manufacture()
        {
        }

        public Manufacture(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static Manufacture Create(string? name, string? nameAr, bool isActive)
        {

            return new Manufacture(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
