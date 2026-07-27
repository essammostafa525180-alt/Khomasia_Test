
namespace Application.CQRS.Partations
{

    public record PartitionLookupResponse(
         int Id,
         string? Name,
         bool HasCollection,
         List<HadithCollectionLookupResponse> HadithCollections
     );







}
