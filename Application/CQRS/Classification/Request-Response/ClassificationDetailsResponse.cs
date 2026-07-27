namespace Application.CQRS.Classification
{
    public record ClassificationDetailsResponse
      (
         int Id,
       string? Name,
       string? FullName,
       string? CatNameTakhreej,
       string? Writer,
       string? FullWriterName,
       string? WriterDeath,
       string? AboutBook,
       string? Slug,
       string? Definition,
       int? Rank,
       int? BooksNumber,
       string? CoverImage,
       string? Lang,
       int? StartId,
       int? EndId,
       int? DeathYear,
       int? HadithCollectionId,
       int? Status
        );
}
