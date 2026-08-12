using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class VehicleModel : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? VehicleBrandFk { get; private set; }
        public int? YearFk { get; private set; }
        public VehicleBrand? VehicleBrandFkNavigation { get; private set; }
        public InventoryYear? YearFkNavigation { get; private set; }

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private VehicleModel()
        {
        }

        public VehicleModel(string? code, string? name, string? nameAr, int? vehicleBrandFk, int? yearFk, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            VehicleBrandFk = vehicleBrandFk;
            YearFk = yearFk;
            IsActive = isActive;
        }

        public static VehicleModel Create(string? code, string? name, string? nameAr, int? vehicleBrandFk, int? yearFk, bool isActive)
        {

            return new VehicleModel(code, name, nameAr, vehicleBrandFk, yearFk, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? vehicleBrandFk, int? yearFk, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            VehicleBrandFk = vehicleBrandFk;
            YearFk = yearFk;
            IsActive = isActive;
        }
    }
}
