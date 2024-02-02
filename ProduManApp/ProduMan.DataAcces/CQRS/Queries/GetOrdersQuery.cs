using Microsoft.EntityFrameworkCore;
using ProduMan.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduMan.DataAccess.CQRS.Queries;

public class GetOrdersQuery : BaseQuery<List<Order>>
{
    public string? SearchString { get; set; }
    public string? CustomerName { get; set; }
    public int? PageSize { get; set; }

    public async override Task<List<Order>> Execute(ProduManContext context)
    {
        var orders = context.Orders.AsQueryable();

        if (!string.IsNullOrEmpty(SearchString))
        {
            orders = orders.Where(o =>
                o.NrZamowienia.Contains(SearchString) ||
                o.Temat.Contains(SearchString) ||
                o.Firma.Contains(SearchString));
        }

        if (!string.IsNullOrEmpty(CustomerName))
        {
            orders = orders.Where(o => o.Firma == CustomerName);
        }

        if (PageSize.HasValue && PageSize != 0) 
        {
            orders = orders.Take(PageSize.Value);
        }

        var filteredOrders = await orders.ToListAsync();

        return filteredOrders;
    }
}
