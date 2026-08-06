using Domain.Primitives;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetComponent : AggregateRootEntityBase<int>
    {
        public int? AssetFk { get; set; }
        public int? ComponentFk { get; set; }
        public Asset? AssetFkNavigation { get; set; }
        public Asset? ComponentFkNavigation { get; set; }

        public AssetComponent()
        {
        }

        public AssetComponent(int? assetFk, int? componentFk, bool isActive) : this()
        {
            AssetFk = assetFk;
            ComponentFk = componentFk;
            IsActive = isActive;
        }

        public static AssetComponent Create(int? assetFk, int? componentFk, bool isActive)
        {

            return new AssetComponent(assetFk, componentFk, isActive);
        }

        public void Update(int? assetFk, int? componentFk, bool isActive)
        {
            AssetFk = assetFk;
            ComponentFk = componentFk;
            IsActive = isActive;
        }
    }
}
