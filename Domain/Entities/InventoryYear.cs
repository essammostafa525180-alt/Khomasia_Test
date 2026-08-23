using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.PdaAggregate;
using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;

namespace Domain.Entities
{
    public class InventoryYear : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? Code { get; private set; }

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

        public InventoryYear(string? name ,string? code , bool isActive) : this()
        {
            Name = name;
            Code = code;
            IsActive = isActive;
        }

        public static InventoryYear Create(string? name ,string? code, bool isActive)
        {

            return new InventoryYear(name, code, isActive);
        }

        public void Update(string? name,string? code, bool isActive)
        {
            Name = name;
            Code = code;
            IsActive = isActive;
        }
    }
}
