namespace Application.Response;
public class ResponseDto<T>
{
    public T Data { get; set; }
    public string Code { get; set; }
    public string Message { get; set; }
}
