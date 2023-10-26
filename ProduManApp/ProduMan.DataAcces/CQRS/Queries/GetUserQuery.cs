using Microsoft.EntityFrameworkCore;
using ProduMan.DataAccess.Entities;

namespace ProduMan.DataAccess.CQRS.Queries;

public class GetUserQuery :QueryBase<User>
{
    public string Username { get; set; }
    
    public override Task<User> Execute(ProduManContext context)
    {
        return context.Users.FirstOrDefaultAsync(u => u.Username == Username);
    }
}