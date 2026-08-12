using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemBudgetDetail : AggregateRootEntityBase<int>
    {
        public int? InventoryItemBudgetFk { get; set; }
        public int? ItemTypeFk { get; set; }
        public long? InventoryItemFk { get; set; }
        public int? BudgetQuantity { get; set; }
        public decimal? BudgetCost { get; set; }
        public InventoryItemBudget? InventoryItemBudgetFkNavigation { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public ItemType? ItemTypeFkNavigation { get; set; }

        public InventoryItemBudgetDetail()
        {
        }

        public InventoryItemBudgetDetail(int? inventoryItemBudgetFk, int? itemTypeFk, long? inventoryItemFk, int? budgetQuantity, decimal? budgetCost, bool isActive) : this()
        {
            InventoryItemBudgetFk = inventoryItemBudgetFk;
            ItemTypeFk = itemTypeFk;
            InventoryItemFk = inventoryItemFk;
            BudgetQuantity = budgetQuantity;
            BudgetCost = budgetCost;
            IsActive = isActive;
        }

        public static InventoryItemBudgetDetail Create(int? inventoryItemBudgetFk, int? itemTypeFk, long? inventoryItemFk, int? budgetQuantity, decimal? budgetCost, bool isActive)
        {

            return new InventoryItemBudgetDetail(inventoryItemBudgetFk, itemTypeFk, inventoryItemFk, budgetQuantity, budgetCost, isActive);
        }

        public void Update(int? inventoryItemBudgetFk, int? itemTypeFk, long? inventoryItemFk, int? budgetQuantity, decimal? budgetCost, bool isActive)
        {
            InventoryItemBudgetFk = inventoryItemBudgetFk;
            ItemTypeFk = itemTypeFk;
            InventoryItemFk = inventoryItemFk;
            BudgetQuantity = budgetQuantity;
            BudgetCost = budgetCost;
            IsActive = isActive;
        }
    }
}
