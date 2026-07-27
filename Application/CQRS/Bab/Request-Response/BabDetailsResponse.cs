namespace Application.CQRS.Bab
{
    public record BabDetailsResponse
   (int id,
string Name,
        int? BabIndex, int? BookId,
 bool IsAvailable);
}
