using MediatR;
using ProduMan.DataAccess;
using ProduMan.DataAccess.Entities;

namespace ProduManApplicationServices.API.Domain;

public class UpdateProductionBatchRequest : IRequest<UpdateProductionBatchResponse>
{
    public int Id { get; set; }
    
    public string CustomerOrderNumber { get; set; }
    
    public int Quantity { get; set; }
    
    public ProductionStatus Status { get; set; }
}