using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.InventoryItemAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AssetsGroup : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public decimal? DepreciationDuration { get; private set; }
        public decimal? DepreciationRate { get; private set; }

        private List<Asset> _assets = new List<Asset>();
        public IReadOnlyCollection<Asset> Assets => _assets;

        private List<AssignAssetTypeToAssetGroup> _assignAssetTypeToAssetGroups = new List<AssignAssetTypeToAssetGroup>();
        public IReadOnlyCollection<AssignAssetTypeToAssetGroup> AssignAssetTypeToAssetGroups => _assignAssetTypeToAssetGroups;

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems;

        private List<ToolsType> _toolsTypes = new List<ToolsType>();
        public IReadOnlyCollection<ToolsType> ToolsTypes => _toolsTypes;

        private AssetsGroup()
        {
        }

        public AssetsGroup(string? name, string? nameAr, decimal? depreciationDuration, decimal? depreciationRate, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            DepreciationDuration = depreciationDuration;
            DepreciationRate = depreciationRate;
            IsActive = isActive;
        }

        public static AssetsGroup Create(string? name, string? nameAr, decimal? depreciationDuration, decimal? depreciationRate, bool isActive)
        {

            return new AssetsGroup(name, nameAr, depreciationDuration, depreciationRate, isActive);
        }

        public void Update(string? name, string? nameAr, decimal? depreciationDuration, decimal? depreciationRate, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            DepreciationDuration = depreciationDuration;
            DepreciationRate = depreciationRate;
            IsActive = isActive;
        }
    }
}
