using Domain.Aggregates.VendorAggregate;
using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderVendorSelection : AggregateRootEntityBase<int>
    {
        public int? VendorOrderFk { get; set; }
        public int? VendorFk { get; set; }
        public bool IsSelected { get; set; }
        public Vendor? VendorFkNavigation { get; set; }
        public VendorOrder? VendorOrderFkNavigation { get; set; }

        public VendorOrderVendorSelection()
        {
        }

        public VendorOrderVendorSelection(int? vendorOrderFk, int? vendorFk, bool isSelected, bool isActive) : this()
        {
            VendorOrderFk = vendorOrderFk;
            VendorFk = vendorFk;
            IsSelected = isSelected;
            IsActive = isActive;
        }

        public static VendorOrderVendorSelection Create(int? vendorOrderFk, int? vendorFk, bool isSelected, bool isActive)
        {

            return new VendorOrderVendorSelection(vendorOrderFk, vendorFk, isSelected, isActive);
        }

        public void Update(int? vendorOrderFk, int? vendorFk, bool isSelected, bool isActive)
        {
            VendorOrderFk = vendorOrderFk;
            VendorFk = vendorFk;
            IsSelected = isSelected;
            IsActive = isActive;
        }
    }
}
