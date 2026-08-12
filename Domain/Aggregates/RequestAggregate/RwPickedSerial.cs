using Domain.Primitives;

namespace Domain.Aggregates.RequestAggregate
{
    public class RwPickedSerial : AggregateRootEntityBase<int>
    {
        public int? RwPickedBatchFk { get; set; }
        public int? SerialFk { get; set; }
        public bool? Axsynced { get; set; }
        public RwPickedBatch? RwPickedBatchFkNavigation { get; set; }

        public RwPickedSerial()
        {
        }

        public RwPickedSerial(int? rwPickedBatchFk, int? serialFk, bool? axsynced, bool isActive) : this()
        {
            RwPickedBatchFk = rwPickedBatchFk;
            SerialFk = serialFk;
            Axsynced = axsynced;
            IsActive = isActive;
        }

        public static RwPickedSerial Create(int? rwPickedBatchFk, int? serialFk, bool? axsynced, bool isActive)
        {

            return new RwPickedSerial(rwPickedBatchFk, serialFk, axsynced, isActive);
        }

        public void Update(int? rwPickedBatchFk, int? serialFk, bool? axsynced, bool isActive)
        {
            RwPickedBatchFk = rwPickedBatchFk;
            SerialFk = serialFk;
            Axsynced = axsynced;
            IsActive = isActive;
        }
    }
}
