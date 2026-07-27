using Application.CQRS.Classification;

public record HadithCollectionLookupResponse(
     int Id,
     string? Name,
     bool MainMenuEnabled,
     List<ClassificationLookupResponse> Classifications
 );

