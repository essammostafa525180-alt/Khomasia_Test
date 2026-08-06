using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.VendorOrderAggregate
{
    public class PoserviceOutsource : AggregateRootEntityBase<int>
    {
        public int? PoserviceFk { get; set; }
        public int? WorkerTypeFk { get; set; }
        public int? EmployeeJobFk { get; set; }
        public int? Quantity { get; set; }
        public decimal? CostPerDay { get; set; }
        public decimal? TotalCost { get; set; }
        public int? ContractTaskEmployeeId { get; set; }
        public EmployeeJob? EmployeeJobFkNavigation { get; set; }
        public PurchaseOrderService? PoserviceFkNavigation { get; set; }
        public WorkerType? WorkerTypeFkNavigation { get; set; }

        public PoserviceOutsource()
        {
        }

        public PoserviceOutsource(int? poserviceFk, int? workerTypeFk, int? employeeJobFk, int? quantity, decimal? costPerDay, decimal? totalCost, int? contractTaskEmployeeId, bool isActive) : this()
        {
            PoserviceFk = poserviceFk;
            WorkerTypeFk = workerTypeFk;
            EmployeeJobFk = employeeJobFk;
            Quantity = quantity;
            CostPerDay = costPerDay;
            TotalCost = totalCost;
            ContractTaskEmployeeId = contractTaskEmployeeId;
            IsActive = isActive;
        }

        public static PoserviceOutsource Create(int? poserviceFk, int? workerTypeFk, int? employeeJobFk, int? quantity, decimal? costPerDay, decimal? totalCost, int? contractTaskEmployeeId, bool isActive)
        {

            return new PoserviceOutsource(poserviceFk, workerTypeFk, employeeJobFk, quantity, costPerDay, totalCost, contractTaskEmployeeId, isActive);
        }

        public void Update(int? poserviceFk, int? workerTypeFk, int? employeeJobFk, int? quantity, decimal? costPerDay, decimal? totalCost, int? contractTaskEmployeeId, bool isActive)
        {
            PoserviceFk = poserviceFk;
            WorkerTypeFk = workerTypeFk;
            EmployeeJobFk = employeeJobFk;
            Quantity = quantity;
            CostPerDay = costPerDay;
            TotalCost = totalCost;
            ContractTaskEmployeeId = contractTaskEmployeeId;
            IsActive = isActive;
        }
    }
}
