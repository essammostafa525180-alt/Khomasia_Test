using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class PoserviceType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<PurchaseOrderService> _purchaseOrderServices = new List<PurchaseOrderService>();
        public IReadOnlyCollection<PurchaseOrderService> PurchaseOrderServices => _purchaseOrderServices;

        private PoserviceType()
        {
        }

        public PoserviceType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static PoserviceType Create(string? name, string? nameAr, bool isActive)
        {

            return new PoserviceType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
