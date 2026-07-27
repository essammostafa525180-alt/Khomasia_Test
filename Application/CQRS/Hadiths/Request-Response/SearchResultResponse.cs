namespace Application.CQRS.Hadiths
{
    public record SearchResultResponse(
    int? ClassificationId,
     string? ClassificationName,
     int BookId,
     string? BookName,
     int BabId,
     string? BabName,
     HadithListResponse Hadith
        //int HadithId,
        //string? HadithWithSign,
        //string? HadithWithNoSign,
        //string? Matn

        );
}
