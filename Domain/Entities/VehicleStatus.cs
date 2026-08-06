using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class VehicleStatus : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public string? Description { get; private set; }

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private VehicleStatus()
        {
        }

        public VehicleStatus(string? code, string? name, string? nameAr, string? description, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            Description = description;
            IsActive = isActive;
        }

        public static VehicleStatus Create(string? code, string? name, string? nameAr, string? description, bool isActive)
        {

            return new VehicleStatus(code, name, nameAr, description, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, string? description, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            Description = description;
            IsActive = isActive;
        }
    }
}
