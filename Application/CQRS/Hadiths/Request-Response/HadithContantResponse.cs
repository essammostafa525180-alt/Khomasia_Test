namespace Application.CQRS.Hadiths
{
    public class HadithContantResponse
    {
        public int ClassificationId { get; set; }
        public string? ClassificationName { get; set; }
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int BabId { get; set; }
        public string? BabName { get; set; }
        public List<HadithListResponse> Hadiths { get; set; } = new List<HadithListResponse>();
    }
}
