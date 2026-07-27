namespace Domain.Aggregates.BookAggregate
{
    public class HadithNarrator
    {

        public int Id { get; set; }
        public int Order { get; set; }
        public int NarratorId { get; set; }
        public int HadithId { get; set; }
        public string Name { get; set; }
    }
}
