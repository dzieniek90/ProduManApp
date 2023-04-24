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

        static List<Order> GetSampleOrders()
        {
            return new List<Order>
            {
                new Order { OrderNumber = "ORD001", ProductName = "Smartphone", Quantity = 10, Status = OrderStatuses.NewOrder, Customer = "TechNova" },
                new ComplaintOrder { OrderNumber = "ORD002", ProductName = "Laptop", Quantity = 5, Status = OrderStatuses.Completed, Customer = "Global Net" },
                new ServiceOrder { OrderNumber = "ORD003", ProductName = "Tablet", Quantity = 7, Status = OrderStatuses.InProgres, Customer = "PolskiEko" },
                new Order { OrderNumber = "ORD004", ProductName = "Monitor", Quantity = 15, Status = OrderStatuses.Completed, Customer = "EkoJutra" },
                new ComplaintOrder { OrderNumber = "ORD005", ProductName = "Printer", Quantity = 8, Status = OrderStatuses.Completed, Customer = "Innovateurs" },
                new ServiceOrder { OrderNumber = "ORD006", ProductName = "Headphones", Quantity = 20, Status = OrderStatuses.NewOrder, Customer = "Sol Avanzadas" },
                new Order { OrderNumber = "ORD007", ProductName = "Mouse", Quantity = 30, Status = OrderStatuses.Completed, Customer = "ItaliaFuturo" },
                new Order { OrderNumber = "ORD008", ProductName = "Keyboard", Quantity = 25, Status = OrderStatuses.InProgres, Customer = "DigiZone" },
                new ComplaintOrder { OrderNumber = "ORD009", ProductName = "Webcam", Quantity = 10, Status = OrderStatuses.NewOrder, Customer = "SmartSolutions" },
                new Order { OrderNumber = "ORD010", ProductName = "Microphone", Quantity = 6, Status = OrderStatuses.Completed, Customer = "MegaBytes" },
                new ServiceOrder { OrderNumber = "ORD011", ProductName = "Smartwatch", Quantity = 12, Status = OrderStatuses.InProgres, Customer = "TechNova" },
                new Order { OrderNumber = "ORD012", ProductName = "Camera", Quantity = 5, Status = OrderStatuses.Completed, Customer = "Global Net" },
                new ComplaintOrder { OrderNumber = "ORD013", ProductName = "Speaker", Quantity = 8, Status = OrderStatuses.Completed, Customer = "PolskiEko" },
                new ServiceOrder { OrderNumber = "ORD014", ProductName = "Router", Quantity = 10, Status = OrderStatuses.NewOrder, Customer = "EkoJutra" },
                new ServiceOrder { OrderNumber = "ORD015", ProductName = "Hard Drive", Quantity = 15, Status = OrderStatuses.Completed, Customer = "Innovateurs" },
                new Order { OrderNumber = "ORD016", ProductName = "Memory Card", Quantity = 20, Status = OrderStatuses.NewOrder, Customer = "Sol Avanzadas" },
                new Order { OrderNumber = "ORD017", ProductName = "Power Bank", Quantity = 30, Status = OrderStatuses.Completed, Customer = "ItaliaFuturo" },
                new ComplaintOrder { OrderNumber = "ORD018", ProductName = "USB Cable", Quantity = 25, Status = OrderStatuses.InProgres, Customer = "DigiZone" },
                new ServiceOrder { OrderNumber = "ORD019", ProductName = "Charger", Quantity = 10, Status = OrderStatuses.NewOrder, Customer = "SmartSolutions" },
                new Order { OrderNumber = "ORD020", ProductName = "Phone Case", Quantity = 6, Status = OrderStatuses.Completed, Customer = "MegaBytes" },
                new Order { OrderNumber = "ORD021", ProductName = "SmartPhone", Quantity = 5, Status = OrderStatuses.NewOrder, Customer = "DigiZone" },
                new Order { OrderNumber = "ORD022", ProductName = "Laptop", Quantity = 3, Status = OrderStatuses.Completed, Customer = "PolskiEko" },
                new ComplaintOrder { OrderNumber = "ORD023", ProductName = "Tablet", Quantity = 8, Status = OrderStatuses.InProgres, Customer = "EkoJutra" },
                new ServiceOrder { OrderNumber = "ORD024", ProductName = "SmartWatch", Quantity = 2, Status = OrderStatuses.NewOrder, Customer = "DigiZone" },
                new Order { OrderNumber = "ORD025", ProductName = "Headphones", Quantity = 10, Status = OrderStatuses.Completed, Customer = "ItaliaFuturo" },
                new ComplaintOrder { OrderNumber = "ORD026", ProductName = "Speaker", Quantity = 7, Status = OrderStatuses.InProgres, Customer = "PolskiEko" },
                new Order { OrderNumber = "ORD027", ProductName = "Camera", Quantity = 4, Status = OrderStatuses.NewOrder, Customer = "Innovateurs" },
                new Order { OrderNumber = "ORD028", ProductName = "Printer", Quantity = 6, Status = OrderStatuses.Completed, Customer = "Innovateurs" },
                new ComplaintOrder { OrderNumber = "ORD029", ProductName = "Monitor", Quantity = 9, Status = OrderStatuses.InProgres, Customer = "TechNova" },
                new ServiceOrder { OrderNumber = "ORD0030", ProductName = "Keyboard", Quantity = 1, Status = OrderStatuses.NewOrder, Customer = "SmartSolutions" },
             };

        }
        static List<Customer> GetSampleCustomers()
        {
            return new List<Customer>
            {
                new Customer { Name = "TechNova", Country = "USA" },
                new Customer { Name = "Global Net", Country = "UK" },
                new Customer { Name = "PolskiEko", Country = "Poland" },
                new Customer { Name = "EkoJutra", Country = "Poland" },
                new Customer { Name = "Innovateurs", Country = "France" },
                new Customer { Name = "Sol Avanzadas", Country = "Spain" },
                new Customer { Name = "ItaliaFuturo", Country = "Italy" },
                new Customer { Name = "DigiZone", Country = "UK" },
                new Customer { Name = "SmartSolutions", Country = "Italy" },
                new Customer { Name = "MegaBytes", Country = "Germany" }
            };
        }    
    }
}
