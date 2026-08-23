using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class UnitOfMeasure : AuditableEntityBase<int>
    {
        public string? Type { get; set; }
        public short? Precision { get; set; }
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryItemUoM> _inventoryItemUoMs = new List<InventoryItemUoM>();
        public IReadOnlyCollection<InventoryItemUoM> InventoryItemUoMs => _inventoryItemUoMs;

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems;

        private UnitOfMeasure()
        {
        }

        public UnitOfMeasure(string type, short? precision, string? code, string? name, string? nameAr,  bool isActive) : this()
        {
            Type = type;
            Precision = precision;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static UnitOfMeasure Create(string type, short? precision, string? code, string? name, string? nameAr,  bool isActive)
        {

            return new UnitOfMeasure(type, precision, code, name, nameAr, isActive);
        }

        public void Update(string type, short? precision, string? code, string? name, string? nameAr,  bool isActive)
        {
            Type = type;
            Precision = precision;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
