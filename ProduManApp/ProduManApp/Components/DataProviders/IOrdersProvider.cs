using ProduManApp.Entities;
using ProduManApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.Components.DataProviders
{
    public interface IOrdersProvider
    {
        IEnumerable<Order> GetAllOrdersByOrderType(Type orderType);
        IEnumerable<Customer> GetAllUniqueCustomerCountries();
        double GetAverageQuantity();
        IEnumerable<Order> GetCompletedOrders();
        IEnumerable<string> GetCustomersWithMoreThanTwoOrders();
        IEnumerable<Order> GetFiveOrdersWithHighestQuantity();
        IEnumerable<object> GetOrderCountByCustomer();
        int GetOrderMaxQuantity();
        IEnumerable<IGrouping<OrderStatuses, Order>> GetOrdersGroupedByStatus();
        IEnumerable<Order> GetOrdersWithSpecificCustomerAndQuantity(string customerName, int minQuantity);
        IEnumerable<Order> GetOrdersWithStatusNewOrInProgres();
        IEnumerable<Order> GetPaginatedOrders(int pageNumber, int pageSize);
        IEnumerable<string> GetProductNames();
        IEnumerable<Order> GetSortedOrdersDescending();
        int GetTotalQuantity();
    }
}
