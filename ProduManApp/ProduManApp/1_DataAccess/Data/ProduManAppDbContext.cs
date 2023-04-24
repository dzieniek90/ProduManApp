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
        public ProduManAppDbContext(DbContextOptions<ProduManAppDbContext> options)
             : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<ComplaintOrder> ComplaintOrders { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>()
            //    .HasOne<Customer>(o => o.Customer)
            //    .WithMany(c => c.Orders)
            //    .HasForeignKey(o => o.CustomerId)
            //    .OnDelete(DeleteBehavior.NoAction);

        }
    } 
}
