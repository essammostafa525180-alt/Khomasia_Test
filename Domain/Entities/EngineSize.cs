using Domain.Aggregates.VehicleAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class EngineSize : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }

        private List<Vehicle> _vehicles = new List<Vehicle>();
        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles;

        private EngineSize()
        {
        }

        public EngineSize(string? name, bool isActive) : this()
        {
            Name = name;
            IsActive = isActive;
        }

        public static EngineSize Create(string? name, bool isActive)
        {

            return new EngineSize(name, isActive);
        }

        public void Update(string? name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }
    }
}
