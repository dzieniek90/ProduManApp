using ProduMan.DataAccess.CQRS.Commands;

namespace ProduMan.DataAccess.CQRS;

public class CommandExecutor : ICommandExecutor
{
    private readonly ProduManContext _context;
    
    public CommandExecutor(ProduManContext context)
    {
        _context = context;
    }
    
    public Task<TResult> Execute<TParameters, TResult>(BaseCommand<TParameters, TResult> command)
    {
        return command.Execute(_context);
    }
}