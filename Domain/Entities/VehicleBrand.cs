using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class VehicleBrand : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<VehicleModel> _vehicleModels = new List<VehicleModel>();
        public IReadOnlyCollection<VehicleModel> VehicleModels => _vehicleModels;

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private VehicleBrand()
        {
        }

        public VehicleBrand(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static VehicleBrand Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new VehicleBrand(code, name, nameAr, isActive);
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
