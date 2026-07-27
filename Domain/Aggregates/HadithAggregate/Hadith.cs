using Domain.Aggregates.BookAggregate;
using Domain.Aggregates.BookSharhAggregate;
using Domain.Aggregates.TakhreejAggregate;
using Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates.HadithAggregate
{
    public class Hadith : AggregateRootEntityBase<int>
    {
        public string? HadithWithSign { get; set; }
        public int HId { get; set; }
        public string? HadithWithNoSign { get; set; }
        public string? Hokm { get; set; }
        public int? HadithNumber { get; set; }

        public string? Taraf { get; set; }
        public string? Matn { get; set; }
        public bool HasAudio { get; set; }
        public string? AudioUrl { get; set; }


        public int RawyId { get; set; }
        //public Narrator Narrator { get; set; }

        public int? BabId { get; set; }//Under test
        [ForeignKey(nameof(BabId))]
        public Bab? Bab { get; set; }



        List<HadithSharh> _hadithSharh = new List<HadithSharh>();
        public IReadOnlyCollection<HadithSharh> HadithSharh => _hadithSharh;

        List<HadithTakhreej> _takhreejFrom = new List<HadithTakhreej>();
        public IReadOnlyCollection<HadithTakhreej> TakhreejFrom => _takhreejFrom;

        List<HadithTakhreej> _takhreejTo = new List<HadithTakhreej>();
        public IReadOnlyCollection<HadithTakhreej> TakhreejTo => _takhreejTo;

        List<HadithTranslations> _hadithTranslations = new List<HadithTranslations>();
        public IReadOnlyCollection<HadithTranslations> HadithTranslations => _hadithTranslations;
        public bool IsAvailable { get; set; } = true; // هل الحديث موجود بداخل باب وبداخل كتاب ولا لأ

    }
}
