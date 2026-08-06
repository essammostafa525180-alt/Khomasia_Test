using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.RequestAggregate
{
    public class RwPickedBatch : AggregateRootEntityBase<int>
    {
        public int? RequestWdfk { get; set; }
        public decimal? ReturnedQuantity { get; set; }
        public decimal? PickedQuantity { get; set; }
        public DateTime? PickedDate { get; set; }
        public int? BatchFk { get; set; }
        public bool? Axsynced { get; set; }

        private List<RwPickedSerial> _rwPickedSerials = new List<RwPickedSerial>();
        public IReadOnlyCollection<RwPickedSerial> RwPickedSerials => _rwPickedSerials;

        public RwPickedBatch()
        {
        }

        public RwPickedBatch(int? requestWdfk, decimal? returnedQuantity, decimal? pickedQuantity, DateTime? pickedDate, int? batchFk, bool? axsynced, bool isActive) : this()
        {
            RequestWdfk = requestWdfk;
            ReturnedQuantity = returnedQuantity;
            PickedQuantity = pickedQuantity;
            PickedDate = pickedDate;
            BatchFk = batchFk;
            Axsynced = axsynced;
            IsActive = isActive;
        }

        public static RwPickedBatch Create(int? requestWdfk, decimal? returnedQuantity, decimal? pickedQuantity, DateTime? pickedDate, int? batchFk, bool? axsynced, bool isActive)
        {

            return new RwPickedBatch(requestWdfk, returnedQuantity, pickedQuantity, pickedDate, batchFk, axsynced, isActive);
        }

        public void Update(int? requestWdfk, decimal? returnedQuantity, decimal? pickedQuantity, DateTime? pickedDate, int? batchFk, bool? axsynced, bool isActive)
        {
            RequestWdfk = requestWdfk;
            ReturnedQuantity = returnedQuantity;
            PickedQuantity = pickedQuantity;
            PickedDate = pickedDate;
            BatchFk = batchFk;
            Axsynced = axsynced;
            IsActive = isActive;
        }
    }
}
