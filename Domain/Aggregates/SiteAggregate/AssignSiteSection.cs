using Domain.Primitives;

namespace Domain.Aggregates.SiteAggregate
{
    public class AssignSiteSection : AggregateRootEntityBase<int>
    {
        public AssignSiteSection()
        {
        }

        public AssignSiteSection(bool isActive) : this()
        {
            IsActive = isActive;
        }

        public static AssignSiteSection Create(bool isActive = false) => new AssignSiteSection(isActive);

        public void Update(bool isActive) => IsActive = isActive;
    }
}
