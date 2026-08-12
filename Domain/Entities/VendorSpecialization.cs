using Domain.Aggregates.VendorAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class VendorSpecialization : AuditableEntityBase<int>
    {
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<AssignVendorSpecialization> _assignVendorSpecializations = new List<AssignVendorSpecialization>();
        public IReadOnlyCollection<AssignVendorSpecialization> AssignVendorSpecializations => _assignVendorSpecializations;

        private VendorSpecialization()
        {
        }

        public VendorSpecialization(string? name, string? nameAr, bool isActive) : this()
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static VendorSpecialization Create(string? name, string? nameAr, bool isActive)
        {

            return new VendorSpecialization(name, nameAr, isActive);
        }

        public void Update(string? name, string? nameAr, bool isActive)
        {
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
