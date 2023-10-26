using ProduMan.DataAccess.Entities;

namespace ProduMan.DataAccess.CQRS.Commands;

public class DeleteProductionBatchCommand : BaseCommand<int, bool>
{
    public override async Task<bool> Execute(ProduManContext context)
    {
        var entityToDelete = await context.FindAsync<ProductionBatch>(Parameter);
        if (entityToDelete == null)
        {
            return false;
        }

        context.Remove(entityToDelete);
        await context.SaveChangesAsync();
        return true;
    }
}