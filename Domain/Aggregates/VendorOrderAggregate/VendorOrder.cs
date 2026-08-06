using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrder : AggregateRootEntityBase<int>
    {
        public VendorOrder()
        {
        }

        public VendorOrder(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static VendorOrder Create(bool isActive = false) => new VendorOrder(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
