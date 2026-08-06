using Domain.Primitives;

namespace Domain.Aggregates.SecurityAggregate
{
    public class SecUserSecurableValue : AggregateRootEntityBase<int>
    {
        public string? Value { get; set; }
        public int? SecUserPropertyId { get; set; }
        public SecUserProperty? SecUserProperty { get; set; }

        public SecUserSecurableValue()
        {
        }

        public SecUserSecurableValue(string? value, int? secUserPropertyId, bool isActive) : this()
        {
            Value = value;
            SecUserPropertyId = secUserPropertyId;
            IsActive = isActive;
        }

        public static SecUserSecurableValue Create(string? value, int? secUserPropertyId, bool isActive)
        {

            return new SecUserSecurableValue(value, secUserPropertyId, isActive);
        }

        public void Update(string? value, int? secUserPropertyId, bool isActive)
        {
            Value = value;
            SecUserPropertyId = secUserPropertyId;
            IsActive = isActive;
        }
    }
}
