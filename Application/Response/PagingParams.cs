namespace Application.Response;
public class PagingParams
{
    private const int MaxPageSize = 50;
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;


    public int PageSize { get; set; }
    public string SearchKeyword { get; set; } = string.Empty;
}
