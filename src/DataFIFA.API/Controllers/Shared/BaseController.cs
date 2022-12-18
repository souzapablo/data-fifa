using System.Net;
using DataFIFA.Core.Extensions;
using DataFIFA.Core.Helpers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DataFIFA.API.Controllers.Shared;

[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult CustomResponse(object? result)
    {
        var messageHandler = HttpContext.RequestServices.GetService<IMessageHandler>();

        switch (result)
        {
            case null when messageHandler?.HasMessage == true:
            {
                var error = messageHandler.Messages.First();
                return Response(error.Status, error.Message);
            }
            case null:
                return Response(HttpStatusCode.NotFound, result);
            default:
                return Response(HttpStatusCode.OK, result);
        }
    }

    private new JsonResult Response(HttpStatusCode statusCode, object? data, string? errorMessage)
    {
        CustomResponse result;
        if (string.IsNullOrWhiteSpace(errorMessage))
        {
            var success = statusCode.IsSuccess();

            result = data != null ?
                new CustomResponse(statusCode, success, data) : 
                new CustomResponse(statusCode, success);
        }
        else
        {
            var errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(errorMessage))
                errors.Add(errorMessage);

            result = new CustomResponse(statusCode, false, errors);
        }
        return new JsonResult(result) { StatusCode = (int)result.StatusCode };
    }

    private new JsonResult Response(HttpStatusCode statusCode, object? result) =>
        Response(statusCode, result, null);

    private new JsonResult Response(HttpStatusCode statusCode, string errorMessage) =>
        Response(statusCode, null, errorMessage);
}