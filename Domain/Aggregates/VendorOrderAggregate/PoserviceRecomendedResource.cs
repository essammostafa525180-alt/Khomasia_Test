using Domain.Aggregates.VendorAggregate;
using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class PoserviceRecomendedResource : AggregateRootEntityBase<int>
    {
        public int PoserviceFk { get; set; }
        public int? ContractFk { get; set; }
        public int? EmployeeJobFk { get; set; }
        public int? VendorFk { get; set; }
        public EmployeeJob? EmployeeJobFkNavigation { get; set; }
        public PurchaseOrderService? PoserviceFkNavigation { get; set; }
        public Vendor? VendorFkNavigation { get; set; }

        public PoserviceRecomendedResource()
        {
        }

        public PoserviceRecomendedResource(int poserviceFk, int? contractFk, int? employeeJobFk, int? vendorFk, bool isActive) : this()
        {
            PoserviceFk = poserviceFk;
            ContractFk = contractFk;
            EmployeeJobFk = employeeJobFk;
            VendorFk = vendorFk;
            IsActive = isActive;
        }

        public static PoserviceRecomendedResource Create(int poserviceFk, int? contractFk, int? employeeJobFk, int? vendorFk, bool isActive)
        {

            return new PoserviceRecomendedResource(poserviceFk, contractFk, employeeJobFk, vendorFk, isActive);
        }

        public void Update(int poserviceFk, int? contractFk, int? employeeJobFk, int? vendorFk, bool isActive)
        {
            PoserviceFk = poserviceFk;
            ContractFk = contractFk;
            EmployeeJobFk = employeeJobFk;
            VendorFk = vendorFk;
            IsActive = isActive;
        }
    }
}
