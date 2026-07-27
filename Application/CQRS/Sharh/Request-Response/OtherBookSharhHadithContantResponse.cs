namespace Application.CQRS.Sharh
{
    public record OtherBookSharhHadithContantResponse
   (
  int BookId,
    string BookName,
    List<HadithSharhBookContant> Contant
       );

}
