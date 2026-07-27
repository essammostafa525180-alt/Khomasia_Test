using Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates.HadithAggregate
{
    public class HadithTranslations : AuditableEntityBase<int>
    {
        public int HadithNubmer { get; set; }
        public string? Content { get; set; }
        public string? Sound { get; set; }
        public string? Rawy { get; set; }
        public string? Hokm { get; set; }
        public int LanguageId { get; set; }
        [ForeignKey(nameof(LanguageId))]
        public HadithLanguages HadithLanguages { get; set; }
        public int? HadithId { get; set; }
        [ForeignKey(nameof(HadithId))]
        public Hadith Hadith { get; set; }
    }
}
