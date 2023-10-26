using MediatR;

namespace ProduManApplicationServices.API.Domain;

public class GetProductionBatchesRequest : IRequest<GetProductionBatchesResponse>
{
    public string? CustomerOrderNumber { get; set; }
    
}