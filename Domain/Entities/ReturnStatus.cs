using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.VendorReturnAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ReturnStatus : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<InventoryItemReturn> _inventoryItemReturns = new List<InventoryItemReturn>();
        public IReadOnlyCollection<InventoryItemReturn> InventoryItemReturns => _inventoryItemReturns;

        private List<VendorReturn> _vendorReturns = new List<VendorReturn>();
        public IReadOnlyCollection<VendorReturn> VendorReturns => _vendorReturns;

        private ReturnStatus()
        {
        }

        public ReturnStatus(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static ReturnStatus Create(string? name, string? nameAr, bool isActive)
        {

            return new ReturnStatus(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
