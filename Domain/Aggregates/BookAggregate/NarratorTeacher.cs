using Domain.Primitives;

namespace Domain.Aggregates.BookAggregate
{
    public class NarratorTeacher : AggregateRootEntityBase<int>
    {
        public string Name { get; set; }
        public int? NarratorId { get; set; }
        public Narrator? Narrator { get; set; }
        public string? Kunya { get; set; } = string.Empty; //اسم يبدأ بأبو أو أم ويُستخدم للتعريف أو التشريف، مثل أبو بكر وأم سلمة.
        public string? Honorific { get; set; } = string.Empty; // اللقب الذي اشتهر بيه بين الناس 
        public string? Lineage { get; set; } = string.Empty; // النسب او الاقارب

        public NarratorTeacher()
        {
        }
        public NarratorTeacher(string name, int narratorId, string kunya,
            string honorific, string lineage,
            bool isActive) : this()
        {
            Name = name;
            NarratorId = narratorId;
            Kunya = kunya;
            Honorific = honorific;
            Lineage = lineage;
            //IsActive = isActive;
        }

        public static NarratorTeacher Create(string name, int narratorId, string kunya,
            string honorific, string lineage,
            bool isActive)
        {
            //Validator.NotNullOrWhiteSpace(name);

            return new NarratorTeacher(name, narratorId, kunya, honorific, lineage, isActive);
        }

        public void Update(string name, int narratorId, string kunya,
            string honorific, string lineage,
            bool isActive)
        {
            Name = name;
            NarratorId = narratorId;
            Kunya = kunya;
            Honorific = honorific;
            Lineage = lineage;
            //IsActive = isActive;
        }
    }
}
