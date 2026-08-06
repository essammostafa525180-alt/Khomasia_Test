using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.PdaAggregate;
using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class InventoryYear : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }

        private List<Asset> _assets = new List<Asset>();
        public IReadOnlyCollection<Asset> Assets => _assets;

        private List<Pdadetail> _pdadetails = new List<Pdadetail>();
        public IReadOnlyCollection<Pdadetail> Pdadetails => _pdadetails;

        private List<VehicleModel> _vehicleModels = new List<VehicleModel>();
        public IReadOnlyCollection<VehicleModel> VehicleModels => _vehicleModels;

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private InventoryYear()
        {
        }

        public InventoryYear(string? name, bool isActive) : this()
        {
            Name = name;
            IsActive = isActive;
        }

        public static InventoryYear Create(string? name, bool isActive)
        {

            return new InventoryYear(name, isActive);
        }

        public void Update(string? name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }
    }
}
