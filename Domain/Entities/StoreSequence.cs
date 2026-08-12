using Domain.Primitives;

namespace Domain.Entities
{
    public class StoreSequence : AuditableEntityBase<int>
    {
        public string TableName { get; private set; }
        public int? SequenceValue { get; private set; }

        private StoreSequence()
        {
        }

        public StoreSequence(string tableName, int? sequenceValue, bool isActive) : this()
        {
            TableName = tableName;
            SequenceValue = sequenceValue;
            IsActive = isActive;
        }

        public static StoreSequence Create(string tableName, int? sequenceValue, bool isActive)
        {

            return new StoreSequence(tableName, sequenceValue, isActive);
        }

        public void Update(string tableName, int? sequenceValue, bool isActive)
        {
            TableName = tableName;
            SequenceValue = sequenceValue;
            IsActive = isActive;
        }
    }
}
