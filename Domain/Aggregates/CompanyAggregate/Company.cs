using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.InventoryTransfereAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Aggregates.StoreAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.CompanyAggregate
{
    public class Company : AggregateRootEntityBase<int>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }

        private List<AllowedCompany> _allowedCompanies = new List<AllowedCompany>();
        public IReadOnlyCollection<AllowedCompany> AllowedCompanies => _allowedCompanies;

        private List<ApprovalMatrixConfig> _approvalMatrixConfigs = new List<ApprovalMatrixConfig>();
        public IReadOnlyCollection<ApprovalMatrixConfig> ApprovalMatrixConfigs => _approvalMatrixConfigs;

        private List<InventoryItemBudget> _inventoryItemBudgets = new List<InventoryItemBudget>();
        public IReadOnlyCollection<InventoryItemBudget> InventoryItemBudgets => _inventoryItemBudgets;

        private List<InventoryItemCost> _inventoryItemCosts = new List<InventoryItemCost>();
        public IReadOnlyCollection<InventoryItemCost> InventoryItemCosts => _inventoryItemCosts;

        private List<InventoryTransfere> _inventoryTransfereCompanyFromFkNavigations = new List<InventoryTransfere>();
        public IReadOnlyCollection<InventoryTransfere> InventoryTransfereCompanyFromFkNavigations => _inventoryTransfereCompanyFromFkNavigations;

        private List<InventoryTransfere> _inventoryTransfereCompanyToFkNavigations = new List<InventoryTransfere>();
        public IReadOnlyCollection<InventoryTransfere> InventoryTransfereCompanyToFkNavigations => _inventoryTransfereCompanyToFkNavigations;

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdraws = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws => _inventroyItemRequestWithdraws;

        private List<Project> _projects = new List<Project>();
        public IReadOnlyCollection<Project> Projects => _projects;

        private List<PurchaseOrderService> _purchaseOrderServices = new List<PurchaseOrderService>();
        public IReadOnlyCollection<PurchaseOrderService> PurchaseOrderServices => _purchaseOrderServices;

        private List<Store> _stores = new List<Store>();
        public IReadOnlyCollection<Store> Stores => _stores;

        private List<VendorOrder> _vendorOrders = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrders => _vendorOrders;

        public Company()
        {
        }

        public Company(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static Company Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new Company(code, name, nameAr, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }
    }
}
