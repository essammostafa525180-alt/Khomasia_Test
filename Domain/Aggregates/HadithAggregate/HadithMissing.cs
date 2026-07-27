using Domain.Primitives;

namespace Domain.Aggregates.HadithAggregate
{
    public class HadithMissing : AuditableEntityBase<int>
    {
        public string? HadithWithSign { get; set; }
        public int HadithNumber { get; set; }
        public int SelId { get; set; }
        public string? HadithWithNoSign { get; set; }
        public string? Hokm { get; set; }

        public int HidOld { get; set; }
        public string? Taraf { get; set; }
        public string? Matn { get; set; }
        public int? HavingMp3 { get; set; }


        public int RawyId { get; set; }

        public int? BabId { get; set; }
        //public Bab? Bab { get; set; }
    }
}
