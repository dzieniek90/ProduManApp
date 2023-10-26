using AutoMapper;
using MediatR;
using ProduMan.DataAccess.CQRS;
using ProduMan.DataAccess.CQRS.Queries;
using ProduManApplicationServices.API.Domain;
using ProduManApplicationServices.API.Domain.Models;
using ProduManApplicationServices.API.ErrorHandling;

namespace ProduManApplicationServices.API.Handlers;

public class GetProductionBatchHandler : IRequestHandler<GetProductionBatchByIdRequest, GetProductionBatchByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetProductionBatchHandler(IQueryExecutor queryExecutor, IMapper mapper)
    {
        _queryExecutor = queryExecutor;
        _mapper = mapper;
    }

    public async Task<GetProductionBatchByIdResponse> Handle(GetProductionBatchByIdRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetProductionBatchQuery
        {
            Id = request.Id
        };
        var productionBatch = await _queryExecutor.Execute(query);
        if (productionBatch == null)
        {
            return new GetProductionBatchByIdResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }
        var mappedProductionBatch = _mapper.Map<ProductionBatch>(productionBatch);
        var response = new GetProductionBatchByIdResponse()
        {
            Data = mappedProductionBatch
        };
        return response;
    }
}