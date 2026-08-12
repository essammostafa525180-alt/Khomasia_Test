using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AssetsType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<Asset> _assets = new List<Asset>();
        public IReadOnlyCollection<Asset> Assets => _assets;

        private List<AssignAssetTypeToAssetGroup> _assignAssetTypeToAssetGroups = new List<AssignAssetTypeToAssetGroup>();
        public IReadOnlyCollection<AssignAssetTypeToAssetGroup> AssignAssetTypeToAssetGroups => _assignAssetTypeToAssetGroups;

        private AssetsType()
        {
        }

        public AssetsType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static AssetsType Create(string? name, string? nameAr, bool isActive)
        {

            return new AssetsType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
