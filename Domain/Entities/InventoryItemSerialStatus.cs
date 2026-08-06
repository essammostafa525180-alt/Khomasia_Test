using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class InventoryItemSerialStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryItemSerial> _inventoryItemSerials = new List<InventoryItemSerial>();
        public IReadOnlyCollection<InventoryItemSerial> InventoryItemSerials => _inventoryItemSerials;

        private InventoryItemSerialStatus()
        {
        }

        public InventoryItemSerialStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static InventoryItemSerialStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new InventoryItemSerialStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
