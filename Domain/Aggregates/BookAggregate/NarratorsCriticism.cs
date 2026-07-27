using Domain.Primitives;

namespace Domain.Aggregates.BookAggregate
{
    /// <summary>
    ///  تقييم الرواة بحسب عدالتهم وضبطهم والاقوال المأثورة عنهم
    /// </summary>
    public class NarratorsCriticism : AggregateRootEntityBase<int>
    {
        public string? CriticName { get; set; }
        public string? CriticStatement { get; set; }
        public int? NarratorId { get; set; }
        public Narrator? Narrator { get; set; }

        public NarratorsCriticism()
        {
        }
        public NarratorsCriticism(string criticName, string criticStatement,
            int narratorId, bool isActive) : this()
        {
            CriticName = criticName;
            CriticStatement = criticStatement;
            NarratorId = narratorId;
            IsActive = isActive;
        }

        public static NarratorsCriticism Create(string criticName, string criticStatement,
            int narratorId, bool isActive)
        {
            return new NarratorsCriticism(criticName, criticStatement, narratorId, isActive);
        }

        public void Update(string criticName, string criticStatement,
            int narratorId, bool isActive)
        {
            CriticName = criticName;
            CriticStatement = criticStatement;
            NarratorId = narratorId;
            IsActive = isActive;
        }
    }
}


