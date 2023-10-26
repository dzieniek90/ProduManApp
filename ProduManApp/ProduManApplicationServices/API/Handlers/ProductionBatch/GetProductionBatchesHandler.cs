using AutoMapper;
using MediatR;
using ProduMan.DataAccess.CQRS;
using ProduMan.DataAccess.CQRS.Queries;
using ProduManApplicationServices.API.Domain;
using ProduManApplicationServices.API.Domain.Models;

namespace ProduManApplicationServices.API.Handlers;

public class GetProductionBatchesHandler : IRequestHandler<GetProductionBatchesRequest, GetProductionBatchesResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetProductionBatchesHandler(IQueryExecutor queryExecutor, IMapper mapper)
    {
        _queryExecutor = queryExecutor;
        _mapper = mapper;
    }

    public async Task<GetProductionBatchesResponse> Handle(GetProductionBatchesRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetProductionBatchesQuery
        {
            CustomerOrderNumber = request.CustomerOrderNumber
        };

        var productionBatches = await _queryExecutor.Execute(query);
        var mappedProductionBatches = _mapper.Map<List<ProductionBatch>>(productionBatches);
        var response = new GetProductionBatchesResponse
        {
            Data = mappedProductionBatches.ToList()
        };
        return response;
    }
}