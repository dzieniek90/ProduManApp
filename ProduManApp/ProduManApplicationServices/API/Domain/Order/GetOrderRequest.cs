using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApplicationServices.API.Domain.Order
{
    public class GetOrderRequest : IRequest<GetOrderResponse>
    {
        public int Id { get; set; }
    }
}
