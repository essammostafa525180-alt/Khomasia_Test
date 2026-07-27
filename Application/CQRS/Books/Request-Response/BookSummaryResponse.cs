namespace Application.CQRS.Books.Request_Response
{
    public record BookSummaryResponse
    (
    int Id
       , string Name
       , int ClassificationId
      , bool IsAvailable
       , int ClassificationIndex);
}
