using System.Net;

namespace Application.Responses;

public class ApiResponses<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    public ApiResponses(HttpStatusCode status, string mess, T? data)
    {
        StatusCode = status;
        Message = mess;
        Data = data;
    }
    public ApiResponses(HttpStatusCode status, string mess)
    {
        StatusCode = status;
        Message = mess;
    }
}
