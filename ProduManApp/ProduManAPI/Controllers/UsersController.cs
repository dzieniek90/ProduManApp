using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProduManApplicationServices.API.Domain;

namespace ProduManAPI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : BaseApiController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
    {
        return HandleRequest<GetUsersRequest, GetUsersResponse>(request);
    }
    
    [HttpGet]
    [Route("{username}")]
    public Task<IActionResult> GetUserByUsername([FromRoute] string username)
    {
        var request = new GetUserRequest
        {
            Username = username
        };
        return HandleRequest<GetUserRequest, GetUserResponse>(request);
    }
}