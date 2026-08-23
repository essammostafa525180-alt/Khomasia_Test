using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;

namespace Domain.Entities
{
    /// <summary>
    /// refers to ItemCategory from menshawy entity represents a category 
    /// of materials within a material group in the inventory system.
    /// It contains properties such as MaterialGroupId, Code, Name, and NameAr to 
    /// store relevant information about the material category. The entity also maintains 
    /// collections of associated InventoryItems and MaterialSubCategories.
    /// </summary>
    public class MaterialCategory : AuditableEntityBase<int>
    {
        public int? MaterialGroupId { get; private set; }
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

        public MaterialCategory(int? materialGroupId, string? code, string? name, string? nameAr, bool isActive) : this()
        {
            MaterialGroupId = materialGroupId;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static MaterialCategory Create(int? materialGroupId, string? code, string? name, string? nameAr, bool isActive)
        {

            return new MaterialCategory(materialGroupId, code, name, nameAr, isActive);
        }

        public void Update(int? materialGroupId, string? code, string? name, string? nameAr, bool isActive)
        {
            MaterialGroupId = materialGroupId   ;
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
