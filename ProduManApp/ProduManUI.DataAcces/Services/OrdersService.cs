using ProduManUI.DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace ProduManUI.DataAcces.Services
{
    public class OrdersService //: IOrdersService
    {
        private IHttpService _httpService;
        private readonly string baseUri = "https://localhost:7196/orders";

        public OrdersService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task<IEnumerable<Order>> GetAll(string? searchString, string? customerFilter, string? pageSize)
        {
            // Dodaj parametry tylko jeśli zostały dostarczone
            var uriBuilder = new UriBuilder(baseUri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            if (!string.IsNullOrEmpty(searchString))
            {
                query["searchString"] = searchString;
            }

            if (!string.IsNullOrEmpty(customerFilter))
            {
                query["customerFilter"] = customerFilter;
            }

            if (!string.IsNullOrEmpty(pageSize))
            {
                query["pageSize"] = pageSize;
            }

            uriBuilder.Query = query.ToString();

            return _httpService.Get<IEnumerable<Order>>(uriBuilder.ToString());
        }

        public async Task<int> Create(Order model)
        {
            var result = await _httpService.Post<Order>(baseUri, model);
            return result.Id;
        }

        public async Task<int> Delete(int id)
        {
            await _httpService.Delete($"{baseUri}/{id}");
            return id;
        }

        public async Task<int> Update(Order model)
        {
            var result = await _httpService.Put<Order>($"{baseUri}/{model.Id}", model);
            return result.Id;
        }

        public Task<Order> GetById(int id)
        {
            return _httpService.Get<Order>($"{baseUri}/{id}");
        }
    }
}