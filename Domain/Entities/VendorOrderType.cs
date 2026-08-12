using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class VendorOrderType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<PurchaseOrderService> _purchaseOrderServices = new List<PurchaseOrderService>();
        public IReadOnlyCollection<PurchaseOrderService> PurchaseOrderServices => _purchaseOrderServices;

        private List<VendorOrder> _vendorOrders = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrders => _vendorOrders;

        private VendorOrderType()
        {
        }

        public VendorOrderType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static VendorOrderType Create(string? name, string? nameAr, bool isActive)
        {

            return new VendorOrderType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
