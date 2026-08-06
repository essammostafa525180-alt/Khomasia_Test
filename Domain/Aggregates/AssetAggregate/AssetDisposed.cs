using Domain.Primitives;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetDisposed : AggregateRootEntityBase<int>
    {
        public string? OrganizationName { get; set; }
        public decimal? Cost { get; set; }
        public string? Notes { get; set; }
        public Asset? IdNavigation { get; set; }

        public AssetDisposed()
        {
        }

        public AssetDisposed(string? organizationName, decimal? cost, string? notes, bool isActive) : this()
        {
            OrganizationName = organizationName;
            Cost = cost;
            Notes = notes;
            IsActive = isActive;
        }

        public static AssetDisposed Create(string? organizationName, decimal? cost, string? notes, bool isActive)
        {

            return new AssetDisposed(organizationName, cost, notes, isActive);
        }

        public void Update(string? organizationName, decimal? cost, string? notes, bool isActive)
        {
            OrganizationName = organizationName;
            Cost = cost;
            Notes = notes;
            IsActive = isActive;
        }
    }
}
