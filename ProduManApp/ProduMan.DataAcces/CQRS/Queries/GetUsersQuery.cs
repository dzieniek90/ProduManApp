using Microsoft.EntityFrameworkCore;
using ProduMan.DataAccess.Entities;

namespace ProduMan.DataAccess.CQRS.Queries;

public class GetUsersQuery : QueryBase<List<User>>
{
    public override Task<List<User>> Execute(ProduManContext context)
    {
        return context.Users.ToListAsync();
    }
}