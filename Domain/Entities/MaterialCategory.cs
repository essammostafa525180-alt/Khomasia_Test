using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class MaterialCategory : AuditableEntityBase<int>
    {
        public int? MaterialGroupFk { get; private set; }
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public MaterialGroup? MaterialGroupFkNavigation { get; private set; }

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems;

        private List<MaterialSubCategory> _materialSubCategories = new List<MaterialSubCategory>();
        public IReadOnlyCollection<MaterialSubCategory> MaterialSubCategories => _materialSubCategories;

        private MaterialCategory()
        {
        }

        public MaterialCategory(int? materialGroupFk, string? code, string? name, string? nameAr, bool isActive) : this()
        {
            MaterialGroupFk = materialGroupFk;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static MaterialCategory Create(int? materialGroupFk, string? code, string? name, string? nameAr, bool isActive)
        {

            return new MaterialCategory(materialGroupFk, code, name, nameAr, isActive);
        }

        public void Update(int? materialGroupFk, string? code, string? name, string? nameAr, bool isActive)
        {
            MaterialGroupFk = materialGroupFk;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
