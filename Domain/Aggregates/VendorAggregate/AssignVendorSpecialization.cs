using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.VendorAggregate
{
    public class AssignVendorSpecialization : AggregateRootEntityBase<int>
    {
        public int? VendorFk { get; set; }
        public int? VendorSpecializationFk { get; set; }
        public Vendor? VendorFkNavigation { get; set; }
        public VendorSpecialization? VendorSpecializationFkNavigation { get; set; }

        public AssignVendorSpecialization()
        {
        }

        public AssignVendorSpecialization(int? vendorFk, int? vendorSpecializationFk, bool isActive) : this()
        {
            VendorFk = vendorFk;
            VendorSpecializationFk = vendorSpecializationFk;
            IsActive = isActive;
        }

        public static AssignVendorSpecialization Create(int? vendorFk, int? vendorSpecializationFk, bool isActive)
        {

            return new AssignVendorSpecialization(vendorFk, vendorSpecializationFk, isActive);
        }

        public void Update(int? vendorFk, int? vendorSpecializationFk, bool isActive)
        {
            VendorFk = vendorFk;
            VendorSpecializationFk = vendorSpecializationFk;
            IsActive = isActive;
        }
    }
}
