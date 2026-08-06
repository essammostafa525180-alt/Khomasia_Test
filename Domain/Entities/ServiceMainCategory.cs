using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ServiceMainCategory : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public int? FinanceCostCenterId { get; private set; }

        private List<ApprovalMatrixConfig> _approvalMatrixConfigs = new List<ApprovalMatrixConfig>();
        public IReadOnlyCollection<ApprovalMatrixConfig> ApprovalMatrixConfigs => _approvalMatrixConfigs;

        private List<InventoryItemBudget> _inventoryItemBudgets = new List<InventoryItemBudget>();
        public IReadOnlyCollection<InventoryItemBudget> InventoryItemBudgets => _inventoryItemBudgets;

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdraws = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws => _inventroyItemRequestWithdraws;

        private List<PoserviceDetail> _poserviceDetails = new List<PoserviceDetail>();
        public IReadOnlyCollection<PoserviceDetail> PoserviceDetails => _poserviceDetails;

        private List<PurchaseOrderService> _purchaseOrderServices = new List<PurchaseOrderService>();
        public IReadOnlyCollection<PurchaseOrderService> PurchaseOrderServices => _purchaseOrderServices;

        private List<ServiceCategory> _serviceCategories = new List<ServiceCategory>();
        public IReadOnlyCollection<ServiceCategory> ServiceCategories => _serviceCategories;

        private List<ServiceSubCategory> _serviceSubCategories = new List<ServiceSubCategory>();
        public IReadOnlyCollection<ServiceSubCategory> ServiceSubCategories => _serviceSubCategories;

        private List<Service> _services = new List<Service>();
        public IReadOnlyCollection<Service> Services => _services;

        private List<VendorOrder> _vendorOrders = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrders => _vendorOrders;

        private ServiceMainCategory()
        {
        }

        public ServiceMainCategory(string? code, string? name, string? nameAr, int? financeCostCenterId, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            FinanceCostCenterId = financeCostCenterId;
            IsActive = isActive;
        }

        public static ServiceMainCategory Create(string? code, string? name, string? nameAr, int? financeCostCenterId, bool isActive)
        {

            return new ServiceMainCategory(code, name, nameAr, financeCostCenterId, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, int? financeCostCenterId, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            FinanceCostCenterId = financeCostCenterId;
            IsActive = isActive;
        }
    }
}
