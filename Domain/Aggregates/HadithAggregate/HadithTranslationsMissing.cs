namespace Domain.Aggregates.HadithAggregate
{
    public class HadithTranslationsMissing
    {
        public int Id { get; set; }
        public int Hid { get; set; }
        public string? Content { get; set; }
        public string? Sound { get; set; }
        public string? Rawy { get; set; }
        public string? Hokm { get; set; }
        public int LanguageId { get; set; }
        public int Selid { get; set; }
    }
}
