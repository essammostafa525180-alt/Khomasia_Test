using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Warehouse : AuditableEntityBase<int>
    {
        public int WarehouseTypeFk { get; private set; }
        public WarehouseType? WarehouseTypeFkNavigation { get; private set; }
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? Address { get; private set; }

        private List<StorageUnit> _storageUnits = new List<StorageUnit>();
        public IReadOnlyCollection<StorageUnit> StorageUnits => _storageUnits;

        private Warehouse() { }

        public Warehouse(int warehouseTypeFk, string? code, string? name, string? description, string? address, bool isActive) : this()
        {
            WarehouseTypeFk = warehouseTypeFk;
            Code = code;
            Name = name;
            Description = description;
            Address = address;
            IsActive = isActive;
        }

        public static Warehouse Create(int warehouseTypeFk, string? code, string? name, string? description, string? address, bool isActive)
        {
            return new Warehouse(warehouseTypeFk, code, name, description, address, isActive);
        }

        public void Update(int warehouseTypeFk, string? code, string? name, string? description, string? address, bool isActive)
        {
            WarehouseTypeFk = warehouseTypeFk;
            Code = code;
            Name = name;
            Description = description;
            Address = address;
            IsActive = isActive;
        }
    }
}
