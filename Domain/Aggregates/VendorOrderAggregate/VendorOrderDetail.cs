using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderDetail : AggregateRootEntityBase<int>
    {
        public VendorOrderDetail()
        {
        }

        public VendorOrderDetail(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static VendorOrderDetail Create(bool isActive = false) => new VendorOrderDetail(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
