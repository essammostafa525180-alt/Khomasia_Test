using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AirFilterType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private AirFilterType()
        {
        }

        public AirFilterType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static AirFilterType Create(string? name, string? nameAr, bool isActive)
        {

            return new AirFilterType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
