namespace Application.CQRS.Partations
{
    public record PartitionDetailsResponse
    (int Id,
         string? Name,
         bool HasCollection);
}
