using Domain.Primitives;

namespace Domain.Aggregates.PdaAggregate
{
    public class PdarequestsLog : AggregateRootEntityBase<int>
    {
        public int? RequestFk { get; set; }
        public int? AssignedToFk { get; set; }
        public bool? IsChanged { get; set; }
        public string? PdarequestType { get; set; }

        public PdarequestsLog()
        {
        }

        public PdarequestsLog(int? requestFk, int? assignedToFk, bool? isChanged, string? pdarequestType, bool isActive) : this()
        {
            RequestFk = requestFk;
            AssignedToFk = assignedToFk;
            IsChanged = isChanged;
            PdarequestType = pdarequestType;
            IsActive = isActive;
        }

        public static PdarequestsLog Create(int? requestFk, int? assignedToFk, bool? isChanged, string? pdarequestType, bool isActive)
        {

            return new PdarequestsLog(requestFk, assignedToFk, isChanged, pdarequestType, isActive);
        }

        public void Update(int? requestFk, int? assignedToFk, bool? isChanged, string? pdarequestType, bool isActive)
        {
            RequestFk = requestFk;
            AssignedToFk = assignedToFk;
            IsChanged = isChanged;
            PdarequestType = pdarequestType;
            IsActive = isActive;
        }
    }
}
