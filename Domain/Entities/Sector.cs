using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Sector : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssignCostCenterToSector> _assignCostCenterToSectors = new List<AssignCostCenterToSector>();
        public IReadOnlyCollection<AssignCostCenterToSector> AssignCostCenterToSectors => _assignCostCenterToSectors;

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private Sector()
        {
        }

        public Sector(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static Sector Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new Sector(code, name, nameAr, isActive);
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
