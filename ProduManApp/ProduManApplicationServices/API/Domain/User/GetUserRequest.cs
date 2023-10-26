using MediatR;

namespace ProduManApplicationServices.API.Domain;

public class GetUserRequest : IRequest<GetUserResponse>
{
    public string Username { get; set; }
}