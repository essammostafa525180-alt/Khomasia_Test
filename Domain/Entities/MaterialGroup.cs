using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;

namespace Domain.Entities
{
    /// <summary>
    /// refers to ItemGroup from menshawy entity represents a group of materials in the inventory system. It contains properties such as GroupCode, 
    /// ShortName, Name, and NameAr to store relevant information about the material group. The entity also maintains collections of associated InventoryItems and MaterialCategories.
    /// </summary>
    public class MaterialGroup : AuditableEntityBase<int>
    {
        public string? GroupCode { get; private set; }
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
            GroupCode = code;
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
            GroupCode = code;
            ShortName = shortName;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
