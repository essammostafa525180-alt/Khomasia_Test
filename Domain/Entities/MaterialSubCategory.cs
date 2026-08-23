using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// refers to material ItemSubCategory from menshawy, which is a classification of materials
    /// or products based on their characteristics, properties, or intended use. 
    /// It is a way to group similar items together for easier management 
    /// and organization within an inventory or procurement system.
    /// </summary>
    public class MaterialSubCategory : AuditableEntityBase<int>
    {

        public int? MaterialGroupId { get; private set; }
        public int? MaterialCategoryId { get; private set; }
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public MaterialCategory? MaterialCategory { get; private set; }
        public MaterialGroup? MaterialGroup { get; private set; }

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems;

        private MaterialSubCategory()
        {
        }

        public MaterialSubCategory(int? materialGroupId, int? materialCategoryId, string? code, string? name, string? nameAr, bool isActive) : this()
        {
            MaterialGroupId = materialGroupId;
            MaterialCategoryId = materialCategoryId;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static MaterialSubCategory Create(int? materialGroupId, int? materialCategoryId, string? code, string? name, string? nameAr, bool isActive)
        {

            return new MaterialSubCategory(materialGroupId, materialCategoryId, code, name, nameAr, isActive);
        }

        public void Update(int? materialGroupId, int? materialCategoryId, string? code, string? name, string? nameAr, bool isActive)
        {
            MaterialGroupId = materialGroupId;
            MaterialCategoryId = materialCategoryId;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
