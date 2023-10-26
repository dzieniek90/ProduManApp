namespace ProduMan.DataAccess.CQRS.Commands;

public abstract class BaseCommand<TParameter, TResult>
{
    public TParameter Parameter { get; set; }
    
    public abstract Task<TResult> Execute(ProduManContext context);
}