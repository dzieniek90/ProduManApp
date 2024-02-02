using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProduMan.DataAccess;
using ProduMan.DataAccess.Entities;
using ProduManApplicationServices.API.Domain;

namespace ProduManAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class ProductionBatchesController : BaseApiController
{
    public ProductionBatchesController(IMediator mediator, ILogger<ProductionBatch> logger) : base(mediator)
    {
        logger.LogInformation("[To jest logowanie w ProductionBatchesController]");
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddProductionBatch([FromBody] AddProductionBatchRequest request)
    {
        return await HandleRequest<AddProductionBatchRequest, AddProductionBatchResponse>(request);
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetProductionBatches([FromQuery] GetProductionBatchesRequest request)
    {
        return await HandleRequest<GetProductionBatchesRequest, GetProductionBatchesResponse>(request);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetProductionBatch([FromRoute] int id)
    {
        var request = new GetProductionBatchByIdRequest()
        {
            Id = id
        };
        return await HandleRequest<GetProductionBatchByIdRequest, GetProductionBatchByIdResponse>(request);
    }

    [HttpPut]
    [Route("")]
    public async Task<IActionResult> PutProductionBatch([FromBody] UpdateProductionBatchRequest request)
    {
        return await HandleRequest<UpdateProductionBatchRequest, UpdateProductionBatchResponse>(request);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteProductionBatch([FromRoute] int id)
    {
        var request = new DeleteProductionBatchRequest()
        {
            Id = id
        };
        return await HandleRequest<DeleteProductionBatchRequest, DeleteProductionBatchResponse>(request);
    }
}