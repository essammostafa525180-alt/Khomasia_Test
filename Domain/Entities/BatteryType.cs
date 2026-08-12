using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class BatteryType : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private BatteryType()
        {
        }

        public BatteryType(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static BatteryType Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new BatteryType(code, name, nameAr, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
