using Application.CQRS.Bab;

namespace Application.CQRS.Sharh
{
    public record SharhClassifacationBookResponse
         (int Id,
         string? Name,
         List<BabListResponse> Babs
         );
}
