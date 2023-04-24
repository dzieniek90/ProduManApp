using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProduManAppDbContext>
    {
        public ProduManAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProduManAppDbContext>();
            optionsBuilder.UseSqlServer("Server=WDZIENKOWSKI\\SQLEXPRESS;DataBase= ProduManApp ; integrated security= true ; Encrypt=False");

            return new ProduManAppDbContext(optionsBuilder.Options);
        }
    }
}
