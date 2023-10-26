using System.ComponentModel.DataAnnotations;

namespace ProduMan.DataAccess.Entities;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
}