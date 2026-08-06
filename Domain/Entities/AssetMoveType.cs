using Domain.Aggregates.AssetAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AssetMoveType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssetItemMove> _assetItemMoves = new List<AssetItemMove>();
        public IReadOnlyCollection<AssetItemMove> AssetItemMoves => _assetItemMoves;

        private AssetMoveType()
        {
        }

        public AssetMoveType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static AssetMoveType Create(string? name, string? nameAr, bool isActive)
        {

            return new AssetMoveType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
