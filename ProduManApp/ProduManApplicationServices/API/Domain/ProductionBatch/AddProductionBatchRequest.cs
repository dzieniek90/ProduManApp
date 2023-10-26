using MediatR;
using ProduMan.DataAccess;

namespace ProduManApplicationServices.API.Domain;

public class AddProductionBatchRequest : IRequest<AddProductionBatchResponse>
{
    public string CustomerOrderNumber { get; set; }
    
    public int Quantity { get; set; }
    
    public ProductionStatus Status { get; set; }
}