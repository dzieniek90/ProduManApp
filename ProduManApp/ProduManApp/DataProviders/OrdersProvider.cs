using ProduManApp.Entities;
using ProduManApp.Helpers;
using ProduManApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduManApp.DataProviders
{
    public class OrdersProvider : IOrdersProvider
    {
        IRepository<Order> _orderRepository;
        IRepository<Customer> _customerRepository;
        List<Order> orders;
        List<Customer> customers;
        public OrdersProvider(IRepository<Order> orderRepository, IRepository<Customer> customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            orders = _orderRepository.GetAll().ToList();
            customers = _customerRepository.GetAll().ToList();
        }

        public int GetOrderMaxQuantity()
        {
            return orders.Select(o=>o.Quantity).Max();
        }

        public IEnumerable<Order> GetFiveOrdersWithHighestQuantity()
        {
            return orders.OrderByDescending(o => o.Quantity).Take(5).ToList();
        }

        public IEnumerable<Customer> GetAllUniqueCustomerCountries()
        {
            return customers.DistinctBy(c => c.Country).ToList();
        }
        public IEnumerable<Order> GetCompletedOrders()
        {
            return orders.Where(o => o.Status == OrderStatuses.Completed);
        }

        public IEnumerable<Order> GetSortedOrdersDescending()
        {
            return orders.OrderByDescending(o => o.Quantity);
        }

        public IEnumerable<string> GetProductNames()
        {
            return orders.Select(o => o.ProductName);
        }

        public IEnumerable<IGrouping<OrderStatuses, Order>> GetOrdersGroupedByStatus()
        {
            return orders.GroupBy(o => o.Status);
        }

        public IEnumerable<object> GetOrderCountByCustomer()
        {
            return orders.GroupBy(o => o.Customer)
                .Select(g => new { Customer = g.Key, Count = g.Count() });
        }

        public int GetTotalQuantity()
        {
            return orders.Sum(o => o.Quantity);
        }

        public IEnumerable<Order> GetPaginatedOrders(int pageNumber, int pageSize)
        {
            return orders.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public double GetAverageQuantity()
        {
            return orders.Average(o => o.Quantity);
        }

        public IEnumerable<Order> GetOrdersWithSpecificCustomerAndQuantity(string customerName, int minQuantity)
        {
            return orders.Where(o => o.Customer == customerName && o.Quantity > minQuantity);
        }

        public IEnumerable<Order> GetOrdersWithStatusNewOrInProgres()
        {
            return orders.Where(o => o.Status == OrderStatuses.NewOrder || o.Status == OrderStatuses.InProgres);
        }

        public IEnumerable<string> GetCustomersWithMoreThanTwoOrders()
        {
           return orders.GroupBy(o => o.Customer).Where(g => g.Count() > 2).Select(g => g.Key);
        }

        public IEnumerable<Order> GetAllOrdersByOrderType(Type orderType)
        {
            return orders.Where(o => o.GetType() == orderType);
        }


    }
}
