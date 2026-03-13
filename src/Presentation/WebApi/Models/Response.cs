using System.Net;

namespace WebApi.Models;

public class Response(object data, HttpStatusCode statusCode, bool isErrored = false)
{
    public object Data { get; } = data;
    public HttpStatusCode StatusCode { get; } = statusCode;
    public bool IsErrored { get; } = isErrored;
}