using ProduManApp.DataProviders;
using ProduManApp.Entities;
using ProduManApp.Extensions;
using ProduManApp.Helpers;
using ProduManApp.Repositories;

namespace ProduManApp.UI
{
    public class UserComunication : IUserComunication
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Customer> _customerRepository;
        private OrderLogger _orderLogger;
        private delegate void OperationDelegate();

        public UserComunication(IRepository<Order> orderRepository, IRepository<Customer> customerRepository)
        {
            _orderLogger = new OrderLogger();
            _orderRepository = orderRepository;
            _orderRepository.ItemRemoved += _orderLogger.DeletingOrder;
            _orderRepository.ItemAdded += _orderLogger.AddingOrder;
            _orderRepository.ItemEdited += _orderLogger.EditingOrder;
            _customerRepository = customerRepository;

            if (_orderRepository.GetType() == typeof(ListRepository<Order>))
            {
                UpdateCustomerBase();
                UpdateOrderBase();
            }
        }

        public void Introduce()
        {
            Console.WriteLine("Witaj w menadżerze zleceń!");
        }

        public void SelectAction()
        {
            var exit = false;
            var operationsMap = new Dictionary<char, OperationDelegate>
                {
                    { '1', AddOrder },
                    { '2', DisplayAllOrders },
                    { '3', RemoveOrder },
                    { '4', EditOrderStatus },
                    { '5', UpdateCustomerBase },
                    { '6', UpdateOrderBase },
                    { '7', DisplayReport },
                    { '0', () => exit = true }
                };

            while (true)
            {
                Console.WriteLine("\nWybierz operację:");
                Console.WriteLine("1. Dodaj zlecenie");
                Console.WriteLine("2. Wyświetl wszystkie zlecenia");
                Console.WriteLine("3. Usuń zlecenie");
                Console.WriteLine("4. Edytuj status zlecenia");
                Console.WriteLine("5. Zresetuj bazę klientów");
                Console.WriteLine("6. Zresetuj bazę zleceń");
                Console.WriteLine("7. Pokaż raport");
                Console.WriteLine("0. Wyjdz z programu");

                var operation = Console.ReadKey();

                if (operationsMap.TryGetValue(operation.KeyChar, out var selectedOperation))  selectedOperation();
                else Console.WriteLine("\nBłąd wuboru Operacji!");

                if (exit) break;
            }
        }

        public void Closure()
        {
            Console.WriteLine("\nDo następnego!");
        }


        private void EditOrderStatus()
        {
            while (true)
            {
                var error = "";
                DisplayAllOrders();

                Console.WriteLine("\nPodaj Id zlecenia które status chcesz edytować:");

                var orderId = Console.ReadLine();  // GetOrderByStringId za dużo if i przyda się do Delete
                if (int.TryParse(orderId, out int orderIdInt))
                {
                    var orderToEdit = _orderRepository.GetById(orderIdInt);
                    if (orderToEdit != null)
                    {
                        while (true)
                        {
                            Console.WriteLine("\n\nWbierz nowy status:");
                            Console.WriteLine($"1. {OrderStatuses.NewOrder.ToPolishString()}");
                            Console.WriteLine($"2. {OrderStatuses.InProgres.ToPolishString()}");
                            Console.WriteLine($"3. {OrderStatuses.Completed.ToPolishString()}");

                            var chosenStatus = Console.ReadKey();

                            orderToEdit.Status = chosenStatus.KeyChar switch
                            {
                                '1' => orderToEdit.Status = OrderStatuses.NewOrder,
                                '2' => orderToEdit.Status = OrderStatuses.InProgres,
                                '3' => orderToEdit.Status = OrderStatuses.Completed,
                                _ => orderToEdit.Status = OrderStatuses.None
                            };

                            if (orderToEdit.Status == OrderStatuses.None)
                            {
                                Console.WriteLine("\n\nBrak statusu o podanym numerze.");
                                continue;
                            }
                            _orderRepository.Update(orderToEdit);
                            _orderRepository.Save();
                            Console.WriteLine("\n\nPomyślnie edytowano status zlecenia.");
                            return;
                        }
                    }
                    else error = "\nBrak zamówienia o podanym numerze Id.";
                }
                else error = "\nPodana wartoś nie jest liczbą!";

                Console.WriteLine(error);
            }
        }

        private void RemoveOrder()
        {
            while (true)
            {
                var error = "";
                DisplayAllOrders();

                Console.WriteLine("\nPodaj Id zlecenia które chcesz usunąć:");

                var orderId = Console.ReadLine();
                if (int.TryParse(orderId, out int orderIdInt))
                {
                    var orderToRemove = _orderRepository.GetById(orderIdInt);
                    if (orderToRemove != null)
                    {
                        _orderRepository.Remove(orderToRemove);
                        _orderRepository.Save();
                        Console.WriteLine("\n\nPomyślnie usunięto zlecenie.");
                        return;
                    }
                    else error = "\nBrak zamówienia o podanym numerze Id.";
                }
                else error = "\nPodana wartoś nie jest liczbą!";
                Console.WriteLine(error);
            }
        }

        private void DisplayAllOrders()
        {
            var orders = _orderRepository.GetAll();
            Console.WriteLine("\n\nLista zamówień:");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"Id",-5} {"Nr. zlecenia",-15} {"Nazwa produktu",-20} {"Ilość",-10} {"Klient",-20} {"Status",-15}");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            foreach (var order in orders)
            {
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }

        private void DisplayAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            Console.WriteLine("\n\nLista klientów:");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"{"Id",-5} {"Nazwa",-20} {"Kraj",-20}");
            Console.WriteLine("-----------------------------------------");
            foreach (var customer in customers)
            {
                {
                    Console.WriteLine(customer.ToString());
                }
            }
        }

        private void AddOrder()
        {
            Order? order = null;
            while (true)
            {
                Console.WriteLine("\n\nWbierz typ zlecenia:");
                Console.WriteLine("1. Produkcyjne");
                Console.WriteLine("2. Serwisowe");
                Console.WriteLine("3. Reklamacyjne");

                var operation = Console.ReadKey();

                order = operation.KeyChar switch
                {
                    '1' => new Order(),
                    '2' => new ServiceOrder(),
                    '3' => new ComplaintOrder(),
                    _ => null
                };
  
                if (order != null) break;

                Console.WriteLine("\n Podano zły numer.");
            }

            Console.WriteLine("\n\nPodaj numer zlecenia:");
            order.OrderNumber = Console.ReadLine();

            Console.WriteLine("\nPodaj nazwę produktu:");
            order.ProductName = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("\nPodaj ilość:");
                var quantity = Console.ReadLine();

                if (int.TryParse(quantity, out var quantityInt))
                {
                    order.Quantity = quantityInt;
                    break;
                }
                Console.WriteLine("\nPodana wartoś nie jest liczbą!");
            }

            while (true)
            {
                var error = "";
                DisplayAllCustomers();

                Console.WriteLine("\nPodaj Id klienta:");

                var customerId = Console.ReadLine();
                if (int.TryParse(customerId, out int customerIdInt))
                {
                    var customer = _customerRepository.GetById(customerIdInt);
                    if (customer != null)
                    {
                        order.Customer = customer.Name;
                        break;
                    }
                    else error = "\nBrak klienta o podanym numerze Id.";
                }
                else error = "\nPodana wartoś nie jest liczbą!";
                Console.WriteLine(error);
            }

            order.Status = OrderStatuses.NewOrder;
            _orderRepository.Add(order);
            _orderRepository.Save();
            Console.WriteLine("\nPomyślnie dodano zlecenie.");
        }

        private void DisplayReport()
        {
            IOrdersProvider ordersProvider = new OrdersProvider(_orderRepository, _customerRepository);

            Console.WriteLine("GetOrderMaxQuantity:");
            Console.WriteLine(ordersProvider.GetOrderMaxQuantity());
            Console.WriteLine();

            Console.WriteLine("GetFiveOrdersWithHighestQuantity:");
            foreach (var order in ordersProvider.GetFiveOrdersWithHighestQuantity())
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("GetAllUniqueCustomerCountries:");
            foreach (var customer in ordersProvider.GetAllUniqueCustomerCountries())
            {
                Console.WriteLine(customer.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("GetCompletedOrders:");
            foreach (var order in ordersProvider.GetCompletedOrders())
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("GetSortedOrdersDescending:");
            foreach (var order in ordersProvider.GetSortedOrdersDescending())
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("GetProductNames:");
            foreach (var productName in ordersProvider.GetProductNames())
            {
                Console.WriteLine(productName);
            }
            Console.WriteLine();

            Console.WriteLine("GetOrdersGroupedByStatus:");
            foreach (var group in ordersProvider.GetOrdersGroupedByStatus())
            {
                Console.WriteLine($"Status: {group.Key.ToPolishString()}");
                foreach (var order in group)
                {
                    Console.WriteLine(order.ToString());
                }
            }
            Console.WriteLine();

            Console.WriteLine("GetOrderCountByCustomer:");
            foreach (var item in ordersProvider.GetOrderCountByCustomer())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("GetTotalQuantity:");
            Console.WriteLine(ordersProvider.GetTotalQuantity());
            Console.WriteLine();

            Console.WriteLine("GetPaginatedOrders (Page 3, 5 items per page):");
            foreach (var order in ordersProvider.GetPaginatedOrders(3, 5))
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("GetAverageQuantity:");
            Console.WriteLine(ordersProvider.GetAverageQuantity());
            Console.WriteLine();

            Console.WriteLine("GetOrdersWithSpecificCustomerAndQuantity (Customer: 'TechNova', MinQuantity: 10):");
            foreach (var order in ordersProvider.GetOrdersWithSpecificCustomerAndQuantity("TechNova", 10))
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("GetOrdersWithStatusNewOrInProgres:");
            foreach (var order in ordersProvider.GetOrdersWithStatusNewOrInProgres())
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("GetCustomersWithMoreThanTwoOrders:");
            foreach (var customerName in ordersProvider.GetCustomersWithMoreThanTwoOrders())
            {
                Console.WriteLine(customerName);
            }
            Console.WriteLine();

            Console.WriteLine("GetAllOrdersByOrderType:");
            foreach (var order in ordersProvider.GetAllOrdersByOrderType(typeof(ServiceOrder)))
            {
                Console.WriteLine(order);
            }
            Console.WriteLine();
        }

        private void UpdateCustomerBase()
        {
            var customers = _customerRepository.GetAll();
            foreach (var customer in customers)
            {
                _customerRepository.Remove(customer);
            }
            _customerRepository.Save();

            var newCustomers = new List<Customer>
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
            foreach (var customer in newCustomers)
            {
                _customerRepository.Add(customer);
            }
            _customerRepository.Save();
        }

        private void UpdateOrderBase()
        {
            var orders = _orderRepository.GetAll();
            foreach (var order in orders)
            {
                _orderRepository.Remove(order);
            }
            _orderRepository.Save();

            List<Order> newOrders = new List<Order>
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
            foreach (var newOrder in newOrders)
            {
                _orderRepository.Add(newOrder);
            }
            _orderRepository.Save();
        }
    }
}