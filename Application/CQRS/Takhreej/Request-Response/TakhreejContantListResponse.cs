namespace Application.CQRS.Takhreej
{
    public record TakhreejContantListResponse
     (
          int? ClassificationId,
          string? ClassificationName,
          int? BookId,
          int? BookIndex,
          string? BookName,
          int? BabId,
          int? BabIndex,
          string? BabName,
          int? HadithIdTo,
          int? HadithToNumber,
          string? HadithTextTo,
          int? HadithIdFrom,
          int? HadithFromNumber,
          string? HadithTextFrom

       );
}

