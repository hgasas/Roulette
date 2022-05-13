using Microsoft.AspNetCore.Mvc;
using VirtualRoulette.Common;

namespace VirtualRoulette.Api;

public static class ResponseExtension
{
    public static ActionResult<Response<T>> MatchActionResult<T>(this Response<T> response)
    {
        switch (response.StatusCode)
        {
            case StatusCode.Success:
                return Success(StatusCodes.Status200OK);
            
            case StatusCode.NotFound:
                return Error(StatusCodes.Status404NotFound);
            
            case StatusCode.BadRequest:
            case StatusCode.InvalidPassword:
            case StatusCode.InvalidBet:
                return Error(StatusCodes.Status400BadRequest);
            
            case StatusCode.InternalServerError:
            default:
                return Error(StatusCodes.Status500InternalServerError);
        }

        ObjectResult Success(int statusCode) => new ObjectResult(response.Message)
        {
            StatusCode = statusCode,
            Value = response.Data
        };

        ActionResult Error(int statusCode) => new ContentResult
        {
            StatusCode = statusCode,
            Content = $"Status Code: {statusCode}; {response.Message}",
            ContentType = "text/plain",
        };
    }
}