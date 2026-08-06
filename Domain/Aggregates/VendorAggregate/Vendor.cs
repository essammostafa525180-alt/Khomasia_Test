using Domain.Primitives;

namespace Domain.Aggregates.VendorAggregate
{
    public class Vendor : AggregateRootEntityBase<int>
    {
        public Vendor()
        {
        }

        public Vendor(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static Vendor Create(bool isActive = false) => new Vendor(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
