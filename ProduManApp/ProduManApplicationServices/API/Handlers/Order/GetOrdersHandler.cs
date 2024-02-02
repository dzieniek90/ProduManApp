using AutoMapper;
using MediatR;
using ProduMan.DataAccess.CQRS;
using ProduMan.DataAccess.CQRS.Queries;
using ProduManApplicationServices.API.Domain;
using ProduManApplicationServices.API.Domain.Order;
using ProduManApplicationServices.API.Domain.Order.Models;
using ProduManApplicationServices.API.ErrorHandling;

namespace ProduManApplicationServices.API.Handlers.Order;

public class GetOrdersHandler : IRequestHandler<GetOrdersRequest, GetOrdersResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetOrdersHandler(IQueryExecutor queryExecutor, IMapper mapper)
    {
        _queryExecutor = queryExecutor;
        _mapper = mapper;
    }

    public async Task<GetOrdersResponse> Handle(GetOrdersRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetOrdersQuery()
        {
            CustomerName = request.CustomerFilter,
            SearchString = request.SearchString,
            PageSize = request.PageSize,
        };

        var model = await _queryExecutor.Execute(query);
        if (model == null)
        {
            return new GetOrdersResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedModel = _mapper.Map<List<OrderVM>>(model);

        var response = new GetOrdersResponse()
        {
            Data = mappedModel
        };
        return response;
    }
}