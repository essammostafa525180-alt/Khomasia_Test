using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.LocationAggregate;
using Domain.Aggregates.StoreAggregate;
using Domain.Aggregates.VehicleAggregate;
using Domain.Aggregates.VendorAggregate;
using Domain.Aggregates.ZoneAggregate;
using Domain.Primitives;

namespace Domain.Entities
{
    public class City : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? StateId { get; private set; }
        public int? ProjectId { get; private set; }
        public int? CountryID { get; set; }

        public Country? Country { get; private set; }
        public Project? Project { get; private set; }
        public State? State { get; private set; }

        private List<Location> _locations = new List<Location>();
        public IReadOnlyCollection<Location> Locations => _locations;

        private List<Store> _stores = new List<Store>();
        public IReadOnlyCollection<Store> Stores => _stores;

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private List<Vendor> _vendors = new List<Vendor>();
        public IReadOnlyCollection<Vendor> Vendors => _vendors;

        private List<Zone> _zones = new List<Zone>();
        public IReadOnlyCollection<Zone> Zones => _zones;

        private City()
        {
        }

        public City(string? code, string? name, string? nameAr, int? stateId, int? projectId,int? countryId, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            StateId = stateId;
            ProjectId = projectId;
            CountryID = countryId;
            IsActive = isActive;
        }

        public static City Create(string? code, string? name, string? nameAr, int? stateId, int? projectId, int? countryId, bool isActive)
        {

            return new City(code, name, nameAr, stateId, projectId, countryId, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? stateId, int? projectId, int? countryId, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            StateId = stateId;
            ProjectId = projectId;
            CountryID = countryId;
            IsActive = isActive;
        }
    }
}
