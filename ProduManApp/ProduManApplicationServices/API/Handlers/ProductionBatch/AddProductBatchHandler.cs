using AutoMapper;
using MediatR;
using ProduMan.DataAccess.CQRS;
using ProduMan.DataAccess.CQRS.Commands;
using ProduMan.DataAccess.Entities;
using ProduManApplicationServices.API.Domain;

namespace ProduManApplicationServices.API.Handlers;

public class AddProductBatchHandler : IRequestHandler<AddProductionBatchRequest, AddProductionBatchResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IMapper _mapper;

    public AddProductBatchHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        _commandExecutor = commandExecutor;
        _mapper = mapper;
    }

    public async Task<AddProductionBatchResponse> Handle(AddProductionBatchRequest request,
        CancellationToken cancellationToken)
    {
        var newProductionBatch = _mapper.Map<ProductionBatch>(request);
        var command = new AddProductionBatchCommand
        {
            Parameter = newProductionBatch
        };
        var response = await _commandExecutor.Execute(command);
        return new AddProductionBatchResponse
        {
            Data = _mapper.Map<Domain.Models.ProductionBatch>(response)
        };
    }
}