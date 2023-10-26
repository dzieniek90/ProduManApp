using System.Reflection.Metadata;
using AutoMapper;
using MediatR;
using ProduMan.DataAccess.CQRS;
using ProduMan.DataAccess.CQRS.Commands;
using ProduManApplicationServices.API.Domain;

namespace ProduManApplicationServices.API.Handlers;

public class DeleteProductionBatchHandler : IRequestHandler<DeleteProductionBatchRequest, DeleteProductionBatchResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public DeleteProductionBatchHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<DeleteProductionBatchResponse> Handle(DeleteProductionBatchRequest request,
        CancellationToken cancellationToken)
    {
        var command = new DeleteProductionBatchCommand()
        {
            Parameter = request.Id
        };

        var response = new DeleteProductionBatchResponse()
        {
            Data = await _commandExecutor.Execute(command)
        };
        return response;
    }
}