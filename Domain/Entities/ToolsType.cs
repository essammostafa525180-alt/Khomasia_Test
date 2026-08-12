using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ToolsType : AuditableEntityBase<int>
    {
        public int? AssetGroupFk { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public AssetsGroup? AssetGroupFkNavigation { get; private set; }

        private List<Asset> _assets = new List<Asset>();
        public IReadOnlyCollection<Asset> Assets => _assets;

        private ToolsType()
        {
        }

        public ToolsType(int? assetGroupFk, string? name, string? nameAr, bool isActive) : this()
        {
            AssetGroupFk = assetGroupFk;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static ToolsType Create(int? assetGroupFk, string? name, string? nameAr, bool isActive)
        {

            return new ToolsType(assetGroupFk, name, nameAr, isActive);
        }

        public void Update(int? assetGroupFk, string? name, string? nameAr, bool isActive)
        {
            AssetGroupFk = assetGroupFk;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
