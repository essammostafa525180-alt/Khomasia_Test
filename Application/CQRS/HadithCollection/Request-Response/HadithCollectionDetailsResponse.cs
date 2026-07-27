using Application.CQRS.Classification;


namespace Application.CQRS.HadithCollection
{
    public record HadithCollectionDetailsResponse
  (int Id,
        string? Name,
        bool MainMenuEnabled,
                 List<ClassificationLookupResponse> Classifications
);
}
