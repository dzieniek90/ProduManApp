using System.Net;
using MediatR;
using ProduManApplicationServices.API.Domain.Models;

namespace ProduManApplicationServices.API.Domain;

public class GetProductionBatchesResponse : BaseResponse<List<ProductionBatch>>
{
}