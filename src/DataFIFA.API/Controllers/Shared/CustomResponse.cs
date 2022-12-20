using System.Net;
// ReSharper disable MemberCanBePrivate.Global

namespace DataFIFA.API.Controllers.Shared;

public class CustomResponse
{
    public HttpStatusCode StatusCode { get; private set; }
    public bool Success { get; private set; }
    public object? Data { get; private set; }
    public IEnumerable<string>? Errors { get; private set; }

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