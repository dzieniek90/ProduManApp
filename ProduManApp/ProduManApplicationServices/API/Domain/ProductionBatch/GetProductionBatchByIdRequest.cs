using MediatR;

namespace ProduManApplicationServices.API.Domain;

public class GetProductionBatchByIdRequest : IRequest<GetProductionBatchByIdResponse>
{
    public int Id { get; set; }   
}