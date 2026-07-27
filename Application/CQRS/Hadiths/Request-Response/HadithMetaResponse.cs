namespace Application.CQRS.Hadiths
{
    public class HadithMetaResponse
    {
        public int ClassificationId { get; set; }
        public string? ClassificationName { get; set; }
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int BabId { get; set; }
        public string? BabName { get; set; }
    }
}
