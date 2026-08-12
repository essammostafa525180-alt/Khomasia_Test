using Domain.Primitives;

namespace Domain.Aggregates.RequestAggregate
{
    public class RwPickedQuantity : AggregateRootEntityBase<int>
    {
        public int? RequestWdfk { get; set; }
        public decimal? PickedQuantity { get; set; }
        public DateTime? PickedDate { get; set; }
        public bool? Axsynced { get; set; }
        public InventroyItemRequestWithdrawDetail? RequestWdfkNavigation { get; set; }

        public RwPickedQuantity()
        {
        }

        public RwPickedQuantity(int? requestWdfk, decimal? pickedQuantity, DateTime? pickedDate, bool? axsynced, bool isActive) : this()
        {
            RequestWdfk = requestWdfk;
            PickedQuantity = pickedQuantity;
            PickedDate = pickedDate;
            Axsynced = axsynced;
            IsActive = isActive;
        }

        public static RwPickedQuantity Create(int? requestWdfk, decimal? pickedQuantity, DateTime? pickedDate, bool? axsynced, bool isActive)
        {

            return new RwPickedQuantity(requestWdfk, pickedQuantity, pickedDate, axsynced, isActive);
        }

        public void Update(int? requestWdfk, decimal? pickedQuantity, DateTime? pickedDate, bool? axsynced, bool isActive)
        {
            RequestWdfk = requestWdfk;
            PickedQuantity = pickedQuantity;
            PickedDate = pickedDate;
            Axsynced = axsynced;
            IsActive = isActive;
        }
    }
}
