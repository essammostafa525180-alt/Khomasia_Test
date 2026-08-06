using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Scope : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }

        private List<ApprovalMatrixConfig> _approvalMatrixConfigs = new List<ApprovalMatrixConfig>();
        public IReadOnlyCollection<ApprovalMatrixConfig> ApprovalMatrixConfigs => _approvalMatrixConfigs;

        private List<InventoryItemBudget> _inventoryItemBudgets = new List<InventoryItemBudget>();
        public IReadOnlyCollection<InventoryItemBudget> InventoryItemBudgets => _inventoryItemBudgets;

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdraws = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws => _inventroyItemRequestWithdraws;

        private List<PurchaseOrderService> _purchaseOrderServices = new List<PurchaseOrderService>();
        public IReadOnlyCollection<PurchaseOrderService> PurchaseOrderServices => _purchaseOrderServices;

        private List<VendorOrder> _vendorOrders = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrders => _vendorOrders;

        private Scope()
        {
        }

        public Scope(string? code, string? name, string? nameAr, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            IsActive = isActive;
        }

        public static Scope Create(string? code, string? name, string? nameAr, bool isActive)
        {

            return new Scope(code, name, nameAr, isActive);
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
