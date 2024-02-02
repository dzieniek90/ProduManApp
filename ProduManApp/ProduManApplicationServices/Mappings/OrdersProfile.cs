using AutoMapper;
using ProduMan.DataAccess.Entities;
using ProduManApplicationServices.API.Domain.Order.Models;

namespace ProduManApplicationServices.Mappings
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderVM>();
        }
    }
}