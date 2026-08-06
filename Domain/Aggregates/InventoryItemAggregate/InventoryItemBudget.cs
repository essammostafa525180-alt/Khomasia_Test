using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.LocationAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemBudget : AggregateRootEntityBase<int>
    {
        public int? CompanyFk { get; set; }
        public int? ProjectFk { get; set; }
        public int? LocationFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public int? ScopeFk { get; set; }
        public Company? CompanyFkNavigation { get; set; }
        public Location? LocationFkNavigation { get; set; }
        public Project? ProjectFkNavigation { get; set; }
        public Scope? ScopeFkNavigation { get; set; }
        public ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }

        private List<InventoryItemBudgetDetail> _inventoryItemBudgetDetails = new List<InventoryItemBudgetDetail>();
        public IReadOnlyCollection<InventoryItemBudgetDetail> InventoryItemBudgetDetails => _inventoryItemBudgetDetails;

        public InventoryItemBudget()
        {
        }

        public InventoryItemBudget(int? companyFk, int? projectFk, int? locationFk, int? serviceMainCategoryFk, int? scopeFk, bool isActive) : this()
        {
            CompanyFk = companyFk;
            ProjectFk = projectFk;
            LocationFk = locationFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            ScopeFk = scopeFk;
            IsActive = isActive;
        }

        public static InventoryItemBudget Create(int? companyFk, int? projectFk, int? locationFk, int? serviceMainCategoryFk, int? scopeFk, bool isActive)
        {

            return new InventoryItemBudget(companyFk, projectFk, locationFk, serviceMainCategoryFk, scopeFk, isActive);
        }

        public void Update(int? companyFk, int? projectFk, int? locationFk, int? serviceMainCategoryFk, int? scopeFk, bool isActive)
        {
            CompanyFk = companyFk;
            ProjectFk = projectFk;
            LocationFk = locationFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            ScopeFk = scopeFk;
            IsActive = isActive;
        }
    }
}
