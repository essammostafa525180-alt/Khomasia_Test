using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class VendorOrderVendorSuggested : AggregateRootEntityBase<int>
    {
        public int? VendorOrderFk { get; set; }
        public string? VendorName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public VendorOrder? VendorOrderFkNavigation { get; set; }

        public VendorOrderVendorSuggested()
        {
        }

        public VendorOrderVendorSuggested(int? vendorOrderFk, string? vendorName, string? address, string? phone, string? email, string? website, bool isActive) : this()
        {
            VendorOrderFk = vendorOrderFk;
            VendorName = vendorName;
            Address = address;
            Phone = phone;
            Email = email;
            Website = website;
            IsActive = isActive;
        }

        public static VendorOrderVendorSuggested Create(int? vendorOrderFk, string? vendorName, string? address, string? phone, string? email, string? website, bool isActive)
        {

            return new VendorOrderVendorSuggested(vendorOrderFk, vendorName, address, phone, email, website, isActive);
        }

        public void Update(int? vendorOrderFk, string? vendorName, string? address, string? phone, string? email, string? website, bool isActive)
        {
            VendorOrderFk = vendorOrderFk;
            VendorName = vendorName;
            Address = address;
            Phone = phone;
            Email = email;
            Website = website;
            IsActive = isActive;
        }
    }
}
