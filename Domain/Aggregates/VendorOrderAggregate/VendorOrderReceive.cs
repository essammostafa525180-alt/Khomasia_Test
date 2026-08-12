using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderReceive : AggregateRootEntityBase<int>
    {
        public VendorOrderReceive()
        {
        }

        public VendorOrderReceive(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static VendorOrderReceive Create(bool isActive = false) => new VendorOrderReceive(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
