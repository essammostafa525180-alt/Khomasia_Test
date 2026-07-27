using Domain.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates.BookSharhAggregate
{
    public class HadithSharhMissing : AuditableEntityBase<int>
    {
        public int Id { get; set; }
        public int HadithNumber { get; set; }
        public int? BabId { get; set; }
        public int? BookSharhId { get; set; }
        [ForeignKey(nameof(BookSharhId))]
        public SharhBook? SharhBook { get; set; }
        public string? SharhWithSign { get; set; }
        public string? SharhWithNoSign { get; set; }

        public int HadithId { get; set; }
    }
}
