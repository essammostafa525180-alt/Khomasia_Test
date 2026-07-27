namespace Application.CQRS.HadithCollection
{
    public record HadithCollectionListResponse(
        int Id,
        string? Name,
        bool MainMenuEnabled
    );
}
