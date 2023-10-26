using ProduMan.DataAccess.Entities;

namespace ProduMan.DataAccess.CQRS.Commands;

public class AddProductionBatchCommand : BaseCommand<ProductionBatch, ProductionBatch>
{
    public override async Task<ProductionBatch> Execute(ProduManContext context)
    {
        await context.ProductionBatches.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}