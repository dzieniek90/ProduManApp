using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProduManApplicationServices.API.Domain;
using ProduManApplicationServices.API.Domain.Order;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProduManAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : BaseApiController
    {
        public OrdersController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProductionBatches([FromQuery] GetOrdersRequest request)
        {
            return await HandleRequest<GetOrdersRequest, GetOrdersResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductionBatch([FromRoute] int id)
        {
            var request = new GetOrderRequest()
            {
                Id = id
            };
            return await HandleRequest<GetOrderRequest, GetOrderResponse>(request);
        }
    }
}
