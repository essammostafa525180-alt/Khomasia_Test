using Application.CQRS.Bab;

namespace Application.CQRS.Books
{
    public record BookDetailsWithBabsResponse
     (int ClassificationId,
         string ClassificationName,
         int Id,
             string Name,
             List<BabListResponse> Babs
     );
}
