using Microsoft.EntityFrameworkCore;
using ProduMan.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduMan.DataAccess.CQRS.Queries
{
    public class GetOrderQuery : BaseQuery<Order>
    {
        public int Id { get; set; }

        public async override Task<Order> Execute(ProduManContext context)
        {
            var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == Id);
            return order;
        }
    }
}
