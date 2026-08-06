using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.LocationAggregate;
using Domain.Aggregates.StoreAggregate;
using Domain.Aggregates.VehicleAggregate;
using Domain.Aggregates.VendorAggregate;
using Domain.Aggregates.ZoneAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class City : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? StateFk { get; private set; }
        public int? RelatedProjectFk { get; private set; }
        public bool? Axsynced { get; private set; }
        public Project? RelatedProjectFkNavigation { get; private set; }
        public State? StateFkNavigation { get; private set; }

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

        public City(string? code, string? name, string? nameAr, int? stateFk, int? relatedProjectFk, bool? axsynced, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            StateFk = stateFk;
            RelatedProjectFk = relatedProjectFk;
            Axsynced = axsynced;
            IsActive = isActive;
        }

        public static City Create(string? code, string? name, string? nameAr, int? stateFk, int? relatedProjectFk, bool? axsynced, bool isActive)
        {

            return new City(code, name, nameAr, stateFk, relatedProjectFk, axsynced, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? stateFk, int? relatedProjectFk, bool? axsynced, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            StateFk = stateFk;
            RelatedProjectFk = relatedProjectFk;
            Axsynced = axsynced;
            IsActive = isActive;
        }
    }
}
