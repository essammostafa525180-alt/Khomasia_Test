using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.InventoryTransfereAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ItemType : AuditableEntityBase<int>
    {
        public string? Code { get; private set; }
        public string? Name { get; private set; }
        public string? NameAr { get; private set; }
        public bool? Axsynced { get; private set; }

        private List<InventoryItemBudgetDetail> _inventoryItemBudgetDetails = new List<InventoryItemBudgetDetail>();
        public IReadOnlyCollection<InventoryItemBudgetDetail> InventoryItemBudgetDetails => _inventoryItemBudgetDetails;

        private List<InventoryItem> _inventoryItems = new List<InventoryItem>();
        public IReadOnlyCollection<InventoryItem> InventoryItems => _inventoryItems;

        private List<InventoryTransfere> _inventoryTransferes = new List<InventoryTransfere>();
        public IReadOnlyCollection<InventoryTransfere> InventoryTransferes => _inventoryTransferes;

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdraws = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws => _inventroyItemRequestWithdraws;

        private List<VendorOrder> _vendorOrders = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrders => _vendorOrders;

        private ItemType()
        {
        }

        public ItemType(string? code, string? name, string? nameAr, bool? axsynced, bool isActive) : this()
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            Axsynced = axsynced;
            IsActive = isActive;
        }

        public static ItemType Create(string? code, string? name, string? nameAr, bool? axsynced, bool isActive)
        {

            return new ItemType(code, name, nameAr, axsynced, isActive);
        }

        public void Update(string? code, string? name, string? nameAr, bool? axsynced, bool isActive)
        {
            Code = code;
            Name = name;
            NameAr = nameAr;
            Axsynced = axsynced;
            IsActive = isActive;
        }
    }
}
