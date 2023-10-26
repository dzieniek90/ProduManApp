using MediatR;

namespace ProduManApplicationServices.API.Domain;

public class DeleteProductionBatchRequest : IRequest<DeleteProductionBatchResponse>
{
    public int Id { get; set; }
}