using AutoMapper;
using MediatR;
using ProduMan.DataAccess.CQRS;
using ProduMan.DataAccess.CQRS.Queries;
using ProduManApplicationServices.API.Domain;
using ProduManApplicationServices.API.Domain.Models;
using ProduManApplicationServices.API.ErrorHandling;

namespace ProduManApplicationServices.API.Handlers;

public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetUserHandler(IQueryExecutor queryExecutor, IMapper mapper)
    {
        _queryExecutor = queryExecutor;
        _mapper = mapper;
    }

    public async Task<GetUserResponse> Handle(GetUserRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetUserQuery()
        {
            Username = request.Username
        };
        var user = await _queryExecutor.Execute(query);
        if (user == null)
        {
            return new GetUserResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var mappedUser = _mapper.Map<User>(user);
        var response = new GetUserResponse()
        {
            Data = mappedUser
        };
        return response;
    }
}