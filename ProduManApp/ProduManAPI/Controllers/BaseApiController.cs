using System.Net;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProduManApplicationServices.API.Domain;
using ProduManApplicationServices.API.ErrorHandling;

namespace ProduManAPI.Controllers;

public abstract class BaseApiController : ControllerBase
{
    protected readonly IMediator _mediator;

    protected BaseApiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
        where TResponse : ErrorResponseBase
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState
                .Where(x => x.Value.Errors.Any())
                .Select(x => new { property = x.Key, errors = x.Value.Errors }));
        }
        
        var userName = User.FindFirstValue(ClaimTypes.Name); // Get the user name from the token
        
        var response = await _mediator.Send(request);
        if (response.Error != null)
        {
            return ErrorResponse(response.Error);
        }

        return Ok(response);
    }

    private IActionResult ErrorResponse(ErrorModel errorModel)
    {
        var httpCode = GetHttpStatusCode(errorModel.Error);
        return StatusCode((int)httpCode, errorModel);
    }

    private object GetHttpStatusCode(string errorType)
    {
        switch (errorType)
        {
            case ErrorType.NotFound:
                return HttpStatusCode.NotFound;
            case ErrorType.InternalServerError:
                return HttpStatusCode.InternalServerError;
            case ErrorType.Unauthorized:
                return HttpStatusCode.Unauthorized;
            case ErrorType.RequestTooLarge:
                return HttpStatusCode.RequestEntityTooLarge;
            case ErrorType.UnsupportedMediaType:
                return HttpStatusCode.UnsupportedMediaType;
            case ErrorType.UnsupportedMethod:
                return HttpStatusCode.MethodNotAllowed;
            case ErrorType.TooManyRequests:
                return (HttpStatusCode)429;
            default:
                return HttpStatusCode.BadRequest;
        }
    }
}