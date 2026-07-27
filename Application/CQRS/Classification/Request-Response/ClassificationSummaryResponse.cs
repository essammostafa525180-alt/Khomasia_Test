using Application.CQRS.Books.Request_Response;

namespace Application.CQRS.Classification
{
    public record ClassificationSummaryResponse
    (int Id,
       string? Name,
            string? AboutBook,
                  bool IsAvailable,


                List<BookSummaryResponse> Books

        );
}
