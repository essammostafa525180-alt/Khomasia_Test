using Domain.Entities;
using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItemUoM : AggregateRootEntityBase<int>
    {
        public long? InventoryItemFk { get; set; }
        public int? UnitOfMeasureFk { get; set; }
        public decimal? ConvertRate { get; set; }
        public InventoryItem? InventoryItemFkNavigation { get; set; }
        public UnitOfMeasure? UnitOfMeasureFkNavigation { get; set; }

        public InventoryItemUoM()
        {
        }

        public InventoryItemUoM(long? inventoryItemFk, int? unitOfMeasureFk, decimal? convertRate, bool isActive) : this()
        {
            InventoryItemFk = inventoryItemFk;
            UnitOfMeasureFk = unitOfMeasureFk;
            ConvertRate = convertRate;
            IsActive = isActive;
        }

        public static InventoryItemUoM Create(long? inventoryItemFk, int? unitOfMeasureFk, decimal? convertRate, bool isActive)
        {

            return new InventoryItemUoM(inventoryItemFk, unitOfMeasureFk, convertRate, isActive);
        }

        public void Update(long? inventoryItemFk, int? unitOfMeasureFk, decimal? convertRate, bool isActive)
        {
            InventoryItemFk = inventoryItemFk;
            UnitOfMeasureFk = unitOfMeasureFk;
            ConvertRate = convertRate;
            IsActive = isActive;
        }
    }
}
