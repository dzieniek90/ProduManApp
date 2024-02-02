using ProduMan.DataAccess.CQRS.Queries;

namespace ProduMan.DataAccess.CQRS;

public class QueryExecutor : IQueryExecutor
{
    protected readonly ProduManContext _context;
    
    public QueryExecutor(ProduManContext context)
    {
        _context = context;
    }
    public Task<TResult> Execute<TResult>(BaseQuery<TResult> query)
    {
        return query.Execute(_context);
    }
}