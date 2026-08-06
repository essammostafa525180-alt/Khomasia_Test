using Domain.Primitives;

namespace Domain.Aggregates.LocationAggregate
{
    public class Location : AggregateRootEntityBase<int>
    {
        public Location()
        {
        }

        public Location(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static Location Create(bool isActive = false) => new Location(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
