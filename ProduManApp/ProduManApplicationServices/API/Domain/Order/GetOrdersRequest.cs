using MediatR;

namespace ProduManApplicationServices.API.Domain.Order;

public class GetOrdersRequest : IRequest<GetOrdersResponse>
{
    public string? SearchString { get; set; }

    public string? CustomerFilter { get; set; }

    public int? PageSize { get; set; }
}