using Domain.Aggregates.BookAggregate;
using Domain.Aggregates.HadithAggregate;
using Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates.TakhreejAggregate
{
    public class HadithTakhreej : AggregateRootEntityBase<int>
    {
        public int HadithIdFrom { get; set; }
        [ForeignKey(nameof(HadithIdFrom))]

        public Hadith HadithFrom { get; set; }

        public int HadithIdTo { get; set; }
        [ForeignKey(nameof(HadithIdTo))]
        public Hadith HadithTo { get; set; }

        public int? BabId { get; set; }
        [ForeignKey(nameof(BabId))]
        public Bab Bab { get; set; }
    }

}
