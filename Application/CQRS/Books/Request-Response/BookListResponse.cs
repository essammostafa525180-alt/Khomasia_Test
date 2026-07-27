namespace Application.CQRS.Books
{
    public record BookListResponse
  (
        int Id,
        string Name,
        int ClassificationId,
        bool IsAvailable,
        int ClassificationIndex,
        int BabCount
    );
}