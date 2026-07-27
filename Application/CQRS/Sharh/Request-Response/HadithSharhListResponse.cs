namespace Application.CQRS
{
    public record HadithSharhListResponse
    (
         int BookId,
      string? BookName,
      List<string?> SharhWithSign,
      List<string?> SharhWithNoSign
        );
}


