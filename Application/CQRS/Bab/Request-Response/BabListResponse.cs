namespace Application.CQRS.Bab
{
    public record BabListResponse
    (int id,
 string Name,
         int? BookId,
         int? BabIndex, bool IsAvailable);

}