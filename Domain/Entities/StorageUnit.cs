using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class StorageUnit : AuditableEntityBase<int>
    {
        public int WarehouseFk { get; private set; }
        public Warehouse? WarehouseFkNavigation { get; private set; }
        public StorageUnitType Type { get; private set; }
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal? Capacity { get; private set; }
        public string? CapacityUnit { get; private set; }

        private List<Isle> _isles = new List<Isle>();
        public IReadOnlyCollection<Isle> Isles => _isles;

        private StorageUnit() { }

        public StorageUnit(int warehouseFk, StorageUnitType type, string? code, string? name, string? description, decimal? capacity, string? capacityUnit, bool isActive) : this()
        {
            WarehouseFk = warehouseFk;
            Type = type;
            Code = code;
            Name = name;
            Description = description;
            Capacity = capacity;
            CapacityUnit = capacityUnit;
            IsActive = isActive;
        }

        public static StorageUnit Create(int warehouseFk, StorageUnitType type, string? code, string? name, string? description, decimal? capacity, string? capacityUnit, bool isActive)
        {
            return new StorageUnit(warehouseFk, type, code, name, description, capacity, capacityUnit, isActive);
        }

        public void Update(int warehouseFk, StorageUnitType type, string? code, string? name, string? description, decimal? capacity, string? capacityUnit, bool isActive)
        {
            WarehouseFk = warehouseFk;
            Type = type;
            Code = code;
            Name = name;
            Description = description;
            Capacity = capacity;
            CapacityUnit = capacityUnit;
            IsActive = isActive;
        }
    }
}
