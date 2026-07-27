namespace Application.CQRS.Sharh
{

    public record HadithSharhBookContant
 (int HadithId,
    int? HadithNumber
    //List<SharhContantResponse> SharhContant
     );

    public record SharhContantResponse
(string? SharhWithSign,
   string? SharhWithNoSign

    );
}