namespace Application.CQRS.Classification;

public record ClassificationLookupResponse(
   int Id,
   string? Name,
    int Type,
      int? DeathYear

);

