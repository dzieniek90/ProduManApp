using AutoMapper;
using MediatR;
using ProduMan.DataAccess.CQRS;
using ProduMan.DataAccess.CQRS.Commands;
using ProduMan.DataAccess.Entities;
using ProduManApplicationServices.API.Domain;

namespace ProduManApplicationServices.API.Handlers;

public class UpdateProductionBatchHandler : IRequestHandler<UpdateProductionBatchRequest, UpdateProductionBatchResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IMapper _mapper;

    public UpdateProductionBatchHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        _commandExecutor = commandExecutor;
        _mapper = mapper;
    }

    public async Task<UpdateProductionBatchResponse> Handle(UpdateProductionBatchRequest request,
        CancellationToken cancellationToken)
    {
        var editedProductionBatch = _mapper.Map<ProductionBatch>(request);
        var command = new UpdateProductionBatchCommand
        {
            Parameter = editedProductionBatch
        };
        var response = await _commandExecutor.Execute(command);
        return new UpdateProductionBatchResponse
        {
            Data = _mapper.Map<Domain.Models.ProductionBatch>(response)
        };
    }
}