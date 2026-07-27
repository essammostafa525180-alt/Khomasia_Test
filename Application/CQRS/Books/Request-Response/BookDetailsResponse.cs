namespace Application.CQRS.Books
{
    public record BookDetailsResponse
   (
   int Id
      , string Name
      , int ClassificationId
     , bool IsAvailable
      , int ClassificationIndex);
}
