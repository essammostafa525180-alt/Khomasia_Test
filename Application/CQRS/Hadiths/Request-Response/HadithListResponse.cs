namespace Application.CQRS.Hadiths
{
    public class HadithListResponse
    {
        public int Id { get; set; }
        public string? HadithWithSign { get; set; }
        public string? HadithWithNoSign { get; set; }
        public string? Matn { get; set; }
        public bool IsAvailable { get; set; }
        public string? AudioUrl { get; set; }
        public int? HadithNumber { get; set; }
        public int BabId { get; set; }
    }
}