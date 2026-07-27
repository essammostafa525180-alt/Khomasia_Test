namespace Application.CQRS.Sharh
{
    public record ClassificationWithBookSharhListResponse
    (
        int Id,
        string? Name,
        List<BookSharhListResponse> SharhBook
    );


}
