using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderQuality : AggregateRootEntityBase<int>
    {
        public VendorOrderQuality()
        {
        }

        public VendorOrderQuality(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static VendorOrderQuality Create(bool isActive = false) => new VendorOrderQuality(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
