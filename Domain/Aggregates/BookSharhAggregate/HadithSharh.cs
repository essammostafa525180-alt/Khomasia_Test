using Domain.Aggregates.HadithAggregate;
using Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates.BookSharhAggregate
{
    public class HadithSharh : AggregateRootEntityBase<int>
    {
        public int HadithNumber { get; set; }
        public int? BabId { get; set; }
        public int? BookSharhId { get; set; }
        [ForeignKey(nameof(BookSharhId))]
        public SharhBook? SharhBook { get; set; }
        public string? SharhWithSign { get; set; }
        public string? SharhWithNoSign { get; set; }
        public bool IsAvailable { get; set; } = true;

        public int HadithId { get; set; }
        [ForeignKey(nameof(HadithId))]
        public Hadith? Hadith { get; set; }
        public HadithSharh()
        {
        }
    }


}
