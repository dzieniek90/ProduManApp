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
        public DbSet<Order> Orders { get; set; }
        public DbSet<ComplaintOrder> ComplaintOrders { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=WDZIENKOWSKI\\SQLEXPRESS;DataBase= ProduManApp ; integrated security= true ; Encrypt=False");
        }
    }
}
