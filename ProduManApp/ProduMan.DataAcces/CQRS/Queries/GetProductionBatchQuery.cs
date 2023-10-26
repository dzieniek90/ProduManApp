using Microsoft.EntityFrameworkCore;
using ProduMan.DataAccess.Entities;

namespace ProduMan.DataAccess.CQRS.Queries;

public class GetProductionBatchQuery : QueryBase<ProductionBatch>
{
    public int Id { get; set; }
    
    public override async Task<ProductionBatch> Execute(ProduManContext context)
    {
        var productionBatch = await context.ProductionBatches.FirstOrDefaultAsync(x => x.Id == Id);
        return productionBatch; 
    }
}