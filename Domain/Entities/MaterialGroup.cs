using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class MaterialGroup : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? ShortName { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems;

        private List<MaterialCategory> _materialCategories = new List<MaterialCategory>();
        public IReadOnlyCollection<MaterialCategory> MaterialCategories => _materialCategories;

        private MaterialGroup()
        {
        }

        public MaterialGroup(string? code, string? shortName, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            ShortName = shortName;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static MaterialGroup Create(string? code, string? shortName, string? name, string? nameAr, bool isActive)
        {

            return new MaterialGroup(code, shortName, name, nameAr, isActive);
        }

        public void Update(string? code, string? shortName, string? name, string? nameAr, bool isActive)
        {
            Code = code;
            ShortName = shortName;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
