using System.ComponentModel.DataAnnotations;

namespace ProduMan.DataAccess.Entities;

public class ProductionBatch : EntityBase
{
    [Required]
    [MaxLength(20)]
    public string CustomerOrderNumber { get; set; }
    
    public int Quantity { get; set; }
    
    public ProductionStatus Status { get; set; }
    
    public List<ReleaseDate>? ReleaseDates { get; set; }
}