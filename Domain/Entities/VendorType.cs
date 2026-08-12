using Domain.Aggregates.VendorAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class VendorType : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<Vendor> _vendors = new List<Vendor>();
        public IReadOnlyCollection<Vendor> Vendors => _vendors;

        private VendorType()
        {
        }

        public VendorType(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static VendorType Create(string? name, string? nameAr, bool isActive)
        {

            return new VendorType(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
