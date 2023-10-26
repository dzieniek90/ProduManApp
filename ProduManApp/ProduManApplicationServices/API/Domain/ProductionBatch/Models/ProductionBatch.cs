using ProduMan.DataAccess;

namespace ProduManApplicationServices.API.Domain.Models;

public class ProductionBatch
{
    public int Id { get; set; }

    public string CustomerOrderNumber { get; set; }
    
    public int Quantity { get; set; }
    
    public ProductionStatus Status { get; set; }
}