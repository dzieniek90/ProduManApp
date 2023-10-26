using System.ComponentModel.DataAnnotations;

namespace ProduMan.DataAccess.Entities;

public class ReleaseDate : EntityBase
{
    [Required]
    public DateTime Date { get; set; }
    
    public int Quantity { get; set; }
    
    public ReleaseStatus Status { get; set; }
    
    public string? Description { get; set; }
    
    public int ProductionBatchId { get; set; }
    
    public ProductionBatch ProductionBatch { get; set; }
}