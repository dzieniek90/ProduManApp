using ProduMan.DataAccess.CQRS.Commands;

namespace ProduMan.DataAccess.CQRS;

public interface ICommandExecutor
{
    Task<TResult> Execute<TParameters, TResult>(BaseCommand<TParameters, TResult> command);
}