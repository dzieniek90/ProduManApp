using System.Runtime.CompilerServices;
using AutoMapper;
using ProduManApplicationServices.API.Domain;
using ProduManApplicationServices.API.Domain.Models;

namespace ProduManApplicationServices.Mappings;

public class ProductionBatchesProfile : Profile
{
    public ProductionBatchesProfile()
    {
        CreateMap<ProduMan.DataAccess.Entities.ProductionBatch, ProductionBatch>();
        CreateMap<AddProductionBatchRequest, ProduMan.DataAccess.Entities.ProductionBatch>();
        CreateMap<UpdateProductionBatchRequest, ProduMan.DataAccess.Entities.ProductionBatch>();
    }
}