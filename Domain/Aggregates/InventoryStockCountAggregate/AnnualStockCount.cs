using Domain.Aggregates.StoreAggregate;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.InventoryStockCountAggregate
{
    public class AnnualStockCount : AggregateRootEntityBase<int>
    {
        public int? YearId { get; set; }
        public int? StoreFk { get; set; }
        public bool IsCompleted { get; set; }
        public Store? StoreFkNavigation { get; set; }

        private List<AnnualStockCountItemMerge> _annualStockCountItemMerges = new List<AnnualStockCountItemMerge>();
        public IReadOnlyCollection<AnnualStockCountItemMerge> AnnualStockCountItemMerges => _annualStockCountItemMerges;

        public AnnualStockCount()
        {
        }

        public AnnualStockCount(int? yearId, int? storeFk, bool isCompleted, bool isActive) : this()
        {
            YearId = yearId;
            StoreFk = storeFk;
            IsCompleted = isCompleted;
            IsActive = isActive;
        }

        public static AnnualStockCount Create(int? yearId, int? storeFk, bool isCompleted, bool isActive)
        {

            return new AnnualStockCount(yearId, storeFk, isCompleted, isActive);
        }

        public void Update(int? yearId, int? storeFk, bool isCompleted, bool isActive)
        {
            YearId = yearId;
            StoreFk = storeFk;
            IsCompleted = isCompleted;
            IsActive = isActive;
        }
    }
}
