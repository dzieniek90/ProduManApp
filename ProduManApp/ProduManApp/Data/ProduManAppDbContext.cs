using Microsoft.EntityFrameworkCore;
using ProduManApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Data
{
    public class ProduManAppDbContext : DbContext
    {
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<ComplaintOrder> ComplaintOrders => Set<ComplaintOrder>();
        public DbSet<ServiceOrder> ServiceOrders => Set<ServiceOrder>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("ProduManAppDb");
        }
    }
}
