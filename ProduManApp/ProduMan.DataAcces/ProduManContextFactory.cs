using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProduMan.DataAccess;

public class ProduManContextFactory : IDesignTimeDbContextFactory<ProduManContext>
{
    public ProduManContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProduManContext>();
        optionsBuilder.UseSqlServer("Server=WDZIENKOWSKI\\SQLEXPRESS;DataBase= ProduMan ; integrated security= true ; Encrypt=False");
        return new ProduManContext(optionsBuilder.Options);
    }
}