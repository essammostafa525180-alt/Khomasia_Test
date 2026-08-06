using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class UnitOfMeasure : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public bool? Axsynced { get; private set; }

        private List<InventoryItemUoM> _inventoryItemUoMs = new List<InventoryItemUoM>();
        public IReadOnlyCollection<InventoryItemUoM> InventoryItemUoMs => _inventoryItemUoMs;

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems;

        private UnitOfMeasure()
        {
        }

        public UnitOfMeasure(string? code, string? name, string? nameAr, bool? axsynced, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            Axsynced = axsynced;
            IsActive = isActive;
        }

        public static UnitOfMeasure Create(string? code, string? name, string? nameAr, bool? axsynced, bool isActive)
        {

            return new UnitOfMeasure(code, name, nameAr, axsynced, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, bool? axsynced, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            Axsynced = axsynced;
            IsActive = isActive;
        }
    }
}
