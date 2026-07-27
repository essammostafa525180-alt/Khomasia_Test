namespace Application.CQRS.Sharh
{
    public class SharhBookMetaResponse
    {
        public int SharhBookId { get; set; }
        public string SharhBookName { get; set; }
        public string SharhBookAuthor { get; set; }
        public int ClassificationId { get; set; }
        public string ClassificationName { get; set; }
        public int BookCount { get; set; }
        public int BabCount { get; set; }
        public int HadithCount { get; set; }
    }
}
