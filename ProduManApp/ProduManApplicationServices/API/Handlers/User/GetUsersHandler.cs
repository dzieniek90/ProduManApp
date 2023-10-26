using AutoMapper;
using MediatR;
using ProduMan.DataAccess.CQRS;
using ProduMan.DataAccess.CQRS.Queries;
using ProduManApplicationServices.API.Domain;
using ProduManApplicationServices.API.Domain.Models;
using ProduManApplicationServices.API.ErrorHandling;

namespace ProduManApplicationServices.API.Handlers;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetUsersHandler(IQueryExecutor queryExecutor, IMapper mapper)
    {
        _queryExecutor = queryExecutor;
        _mapper = mapper;
    }

    public async Task<GetUsersResponse> Handle(GetUsersRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetUsersQuery();
        var users = await _queryExecutor.Execute(query);
        if (users == null)
        {
            return new GetUsersResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var mappedUsers = _mapper.Map<List<User>>(users);
        var response = new GetUsersResponse()
        {
            Data = mappedUsers
        };
        return response;
    }
}