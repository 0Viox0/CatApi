using Bll.CustomExceptions;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatApi.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var statusCode = context.Exception switch
        {
            OwnerNotFoundException => StatusCodes.Status404NotFound,
            CatNotFoundException => StatusCodes.Status404NotFound,
            OwnerAlreadyExistsException => StatusCodes.Status409Conflict,
            InvalidCatColorException => StatusCodes.Status400BadRequest,
            FriendsWithItselfException => StatusCodes.Status400BadRequest,
            CatAlreadyHasAnOwner => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = "An error occured while processing the request",
            Detail = context.Exception.Message,
            Instance = context.HttpContext.Request.Path
        };

        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = statusCode
        };

        context.ExceptionHandled = true;
    }
}
