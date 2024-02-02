using Microsoft.EntityFrameworkCore;
using ProduMan.DataAccess.Entities;

namespace ProduMan.DataAccess.CQRS.Queries;

public class GetProductionBatchesQuery : BaseQuery<List<ProductionBatch>>
{
    public string? CustomerOrderNumber { get; set; }

    public override Task<List<ProductionBatch>> Execute(ProduManContext context)
    {
        var query = context.ProductionBatches.AsQueryable();

        if (!string.IsNullOrEmpty(CustomerOrderNumber))
        {
            query = query.Where(x => x.CustomerOrderNumber == CustomerOrderNumber);
        }

        return query.ToListAsync();
    }
}