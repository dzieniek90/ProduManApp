using AutoMapper;
using MediatR;
using ProduMan.DataAccess.CQRS;
using ProduMan.DataAccess.CQRS.Queries;
using ProduManApplicationServices.API.Domain;
using ProduManApplicationServices.API.Domain.Order;
using ProduManApplicationServices.API.Domain.Order.Models;
using ProduManApplicationServices.API.ErrorHandling;

namespace ProduManApplicationServices.API.Handlers.Order;

public class GetOrderHandler : IRequestHandler<GetOrderRequest, GetOrderResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetOrderHandler(IQueryExecutor queryExecutor, IMapper mapper)
    {
        _queryExecutor = queryExecutor;
        _mapper = mapper;
    }

    public async Task<GetOrderResponse> Handle(GetOrderRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetOrderQuery()
        {
            Id = request.Id
        };
        var model = await _queryExecutor.Execute(query);
        if (model == null)
        {
            return new GetOrderResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var mappedModel = _mapper.Map<OrderVM>(model);
        var response = new GetOrderResponse()
        {
            Data = mappedModel
        };
        return response;
    }
}