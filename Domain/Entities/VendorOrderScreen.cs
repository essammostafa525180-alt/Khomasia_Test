using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class VendorOrderScreen : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }

        private List<PurchaseOrderService> _purchaseOrderServices = new List<PurchaseOrderService>();
        public IReadOnlyCollection<PurchaseOrderService> PurchaseOrderServices => _purchaseOrderServices;

        private List<VendorOrder> _vendorOrders = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrders => _vendorOrders;

        private VendorOrderScreen()
        {
        }

        public VendorOrderScreen(string? code, string? name, bool isActive) : this()
        {
            Code = code;
            Name = name;
            IsActive = isActive;
        }

        public static VendorOrderScreen Create(string? code, string? name, bool isActive)
        {

            return new VendorOrderScreen(code, name, isActive);
        }

        public void Update(string? code, string? name, bool isActive)
        {
            Code = code;
            Name = name;
            IsActive = isActive;
        }
    }
}
