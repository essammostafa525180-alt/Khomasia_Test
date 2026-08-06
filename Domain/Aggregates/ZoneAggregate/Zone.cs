using Domain.Primitives;

namespace Domain.Aggregates.ZoneAggregate
{
    public class Zone : AggregateRootEntityBase<int>
    {
        public Zone()
        {
        }

        public Zone(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static Zone Create(bool isActive = false) => new Zone(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
