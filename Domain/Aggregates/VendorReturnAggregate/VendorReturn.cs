using Domain.Primitives;

namespace Domain.Aggregates.VendorReturnAggregate
{
    public class VendorReturn : AggregateRootEntityBase<int>
    {
        public VendorReturn()
        {
        }

        public VendorReturn(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static VendorReturn Create(bool isActive = false) => new VendorReturn(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
