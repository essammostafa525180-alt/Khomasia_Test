using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Ownership : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private Ownership()
        {
        }

        public Ownership(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static Ownership Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new Ownership(code, name, nameAr, isActive);
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
