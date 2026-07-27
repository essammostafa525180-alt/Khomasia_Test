namespace Application.CQRS.Sharh
{
    public record SharhBabListResponse
     (
         int HadithNumber,
         string? SharhWithSign,
         string? SharhWithNoSign,
         int HadithId
      );
}