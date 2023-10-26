using AutoMapper;
using ProduMan.DataAccess.Entities;

namespace ProduManApplicationServices.Mappings;

public class UsersProfile :Profile
{
    public UsersProfile()
    {
        CreateMap<User, API.Domain.Models.User>();
    }
}