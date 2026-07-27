namespace Application.CQRS.Sharh
{
    public record SharhClassifacationResponse
    (int Id,
        string? Name,
        List<SharhClassifacationBookResponse> Books
        );




}
