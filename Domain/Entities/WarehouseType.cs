using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class WarehouseType : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }

        private List<Warehouse> _warehouses = new List<Warehouse>();
        public IReadOnlyCollection<Warehouse> Warehouses => _warehouses;

        private WarehouseType() { }

        public WarehouseType(string? code, string? name, string? description, bool isActive) : this()
        {
            Code = code;
            Name = name;
            Description = description;
            IsActive = isActive;
        }

        public static WarehouseType Create(string? code, string? name, string? description, bool isActive)
        {
            return new WarehouseType(code, name, description, isActive);
        }

        public void Update(string? code, string? name, string? description, bool isActive)
        {
            Code = code;
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }
}
