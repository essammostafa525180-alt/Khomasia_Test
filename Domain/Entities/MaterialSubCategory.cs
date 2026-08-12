using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class MaterialSubCategory : AuditableEntityBase<int>
    {
        public int? MaterialGroupFk { get; private set; }
        public int? MaterialCategoryFk { get; private set; }
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public MaterialCategory? MaterialCategoryFkNavigation { get; private set; }

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems;

        private MaterialSubCategory()
        {
        }

        public MaterialSubCategory(int? materialGroupFk, int? materialCategoryFk, string? code, string? name, string? nameAr, bool isActive) : this()
        {
            MaterialGroupFk = materialGroupFk;
            MaterialCategoryFk = materialCategoryFk;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static MaterialSubCategory Create(int? materialGroupFk, int? materialCategoryFk, string? code, string? name, string? nameAr, bool isActive)
        {

            return new MaterialSubCategory(materialGroupFk, materialCategoryFk, code, name, nameAr, isActive);
        }

        public void Update(int? materialGroupFk, int? materialCategoryFk, string? code, string? name, string? nameAr, bool isActive)
        {
            MaterialGroupFk = materialGroupFk;
            MaterialCategoryFk = materialCategoryFk;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
