using Microsoft.EntityFrameworkCore;
using ProduMan.DataAccess.Entities;

namespace ProduMan.DataAccess;

public class ProduManContext : DbContext
{
    public ProduManContext(DbContextOptions<ProduManContext> options) : base(options)
    {
    }

    public DbSet<ProductionBatch> ProductionBatches { get; set; }

    public DbSet<ReleaseDate> ReleaseDates { get; set; }
    
    public DbSet<User> Users { get; set; }

    public DbSet<Order> Orders { get; set; }
}