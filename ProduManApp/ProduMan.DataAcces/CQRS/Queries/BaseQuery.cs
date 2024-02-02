namespace ProduMan.DataAccess.CQRS.Queries;

public abstract class BaseQuery<TResult>
{
    public abstract Task<TResult> Execute(ProduManContext context);
}