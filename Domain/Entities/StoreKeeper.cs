using Domain.Aggregates.StoreAggregate;
using Domain.Aggregates.UserAggregate;
using Domain.Primitives;

namespace Domain.Entities
{
    public class StoreKeeper : AuditableEntityBase<int>
    {
        public int? StoreFk { get; private set; }
        public int? StoreKeeperFk { get; private set; }
        public Store? StoreFkNavigation { get; private set; }
        public User? StoreKeeperFkNavigation { get; private set; }

        private StoreKeeper()
        {
        }

        public StoreKeeper(int? storeFk, int? storeKeeperFk, bool isActive) : this()
        {
            StoreFk = storeFk;
            StoreKeeperFk = storeKeeperFk;
            IsActive = isActive;
        }

        public static StoreKeeper Create(int? storeFk, int? storeKeeperFk, bool isActive)
        {

            return new StoreKeeper(storeFk, storeKeeperFk, isActive);
        }

        public void Update(int? storeFk, int? storeKeeperFk, bool isActive)
        {
            StoreFk = storeFk;
            StoreKeeperFk = storeKeeperFk;
            IsActive = isActive;
        }
    }
}
