using System.Net;

namespace DataFIFA.API.Controllers.Shared;

public class CustomResponse
{
    public HttpStatusCode StatusCode { get; private set; }
    private bool Success { get; set; }
    private object Data { get; set; } = null!;
    private IEnumerable<string> Errors { get; set; } = null!;

    public CustomResponse(HttpStatusCode statusCode, bool success)
    {
        StatusCode = statusCode;
        Success = success;
    }

    public CustomResponse(HttpStatusCode statusCode, bool success, object data) : this(statusCode, success) =>
        Data = data;

    public CustomResponse(HttpStatusCode statusCode, bool success, IEnumerable<string> errors) : this(statusCode, success) =>
        Errors = errors;
}