using ProduMan.DataAccess.CQRS.Queries;

namespace ProduMan.DataAccess.CQRS;

public interface IQueryExecutor
{
    Task<TResult> Execute<TResult>(BaseQuery<TResult> query);
}