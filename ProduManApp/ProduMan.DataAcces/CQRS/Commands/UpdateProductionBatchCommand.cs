using ProduMan.DataAccess.Entities;

namespace ProduMan.DataAccess.CQRS.Commands;

public class UpdateProductionBatchCommand : BaseCommand<ProductionBatch, ProductionBatch>
{
    public override async Task<ProductionBatch> Execute(ProduManContext context)
    { 
        context.ProductionBatches.Update(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}