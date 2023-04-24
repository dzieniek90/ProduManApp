using ProduManApp.Components.DataProviders;
using ProduManApp.Data.Repositories;
using ProduManApp.Entities;
using ProduManApp.Extensions;
using ProduManApp.Helpers;

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
                ResetCustomerBase();
                ResetOrderBase();
            }
        }

        public void Introduce()
        {
            Console.WriteLine("\n\nWitaj w menadżerze zleceń!");
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
                { '5', ResetCustomerBase },
                { '6', ResetOrderBase },
                { '7', DisplayReport },
                { '0', () => exit = true }
            };

            while (!exit)
            {
                ShowMenu();
                var operation = Console.ReadKey();

                if (operationsMap.TryGetValue(operation.KeyChar, out var selectedOperation)) selectedOperation();
                else Console.WriteLine("\nBłąd wuboru Operacji!");
            }
        }

        public void Closure()
        {
            Console.WriteLine("\nDo następnego!");
        }

        private void ShowMenu()
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
        }

        private void EditOrderStatus()
        {
            while (true)
            {
                DisplayAllOrders();

                Console.WriteLine("\nPodaj Id zlecenia które status chcesz edytować:");
                var orderId = Console.ReadLine();

                if (int.TryParse(orderId, out int orderIdInt))
                {
                    var orderToEdit = _orderRepository.GetById(orderIdInt);
                    if (orderToEdit != null)
                    {
                        EditStatus(orderToEdit);
                        break;
                    }
                    else Console.WriteLine("\nBrak zamówienia o podanym numerze Id.");
                }
                else Console.WriteLine("\nPodana wartoś nie jest liczbą!");
            }
        }

        private void EditStatus(Order orderToEdit)
        {
            while (true)
            {
                ShowStatusOptions();

                var chosenStatus = Console.ReadKey();
                var newStatus = GetNewStatus(chosenStatus.KeyChar);

                if (newStatus != OrderStatuses.None)
                {
                    orderToEdit.Status = newStatus;
                    _orderRepository.Update(orderToEdit);
                    _orderRepository.Save();
                    Console.WriteLine("\n\nPomyślnie edytowano status zlecenia.");
                    return;
                }
                Console.WriteLine("\n\nBrak statusu o podanym numerze.");
            }
        }

        private void ShowStatusOptions()
        {
            Console.WriteLine("\n\nWbierz nowy status:");
            Console.WriteLine($"1. {OrderStatuses.NewOrder.ToPolishString()}");
            Console.WriteLine($"2. {OrderStatuses.InProgres.ToPolishString()}");
            Console.WriteLine($"3. {OrderStatuses.Completed.ToPolishString()}");
        }

        private OrderStatuses GetNewStatus(char chosenStatus)
        {
            return chosenStatus switch
            {
                '1' => OrderStatuses.NewOrder,
                '2' => OrderStatuses.InProgres,
                '3' => OrderStatuses.Completed,
                _ => OrderStatuses.None
            };
        }

        private void RemoveOrder()
        {
            while (true)
            {
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
                    else Console.WriteLine("\nBrak zamówienia o podanym numerze Id.");
                }
                else Console.WriteLine("\nPodana wartoś nie jest liczbą!");
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
            var order = CreateOrder();

            order.OrderNumber = GetUserInput("\n\nPodaj numer zlecenia:");
            order.ProductName = GetUserInput("\nPodaj nazwę produktu:");
            order.Quantity = GetValidQuantity();

            var customer = GetValidCustomer();

            order.Customer = customer.Name;

            order.Status = OrderStatuses.NewOrder;
            _orderRepository.Add(order);
            _orderRepository.Save();
            Console.WriteLine("\nPomyślnie dodano zlecenie.");
        }

        private Order CreateOrder()
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

            return order;
        }

        private string GetUserInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine("Wartoś nie może być pusta!");
            }
        }

        private int GetValidQuantity()
        {
            while (true)
            {
                var quantity = GetUserInput("\nPodaj ilość:");
                if (int.TryParse(quantity, out var quantityInt))
                {
                    return quantityInt;
                }
                Console.WriteLine("\nPodana wartoś nie jest liczbą!");
            }
        }

        private Customer GetValidCustomer()
        {
            while (true)
            {
                DisplayAllCustomers();
                var customerId = GetUserInput("\nPodaj Id klienta:");
                if (int.TryParse(customerId, out int customerIdInt))
                {
                    var customer = _customerRepository.GetById(customerIdInt);
                    if (customer != null)
                    {
                        return customer;
                    }
                    else Console.WriteLine("\nBrak klienta o podanym numerze Id.");
                }
                else Console.WriteLine("\nPodana wartoś nie jest liczbą!");
            }
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

        public void ResetOrderBase()
        {
            ClearOrderBase();
            AddSampleOrders();
        }

        private void ClearOrderBase()
        {
            var orders = _orderRepository.GetAll();
            foreach (var order in orders)
            {
                _orderRepository.Remove(order);
            }
            _orderRepository.Save();
        }

        private void AddSampleOrders()
        {
            List<Order> newOrders = IOrdersProvider.GetSampleOrders();
            foreach (var newOrder in newOrders)
            {
                _orderRepository.Add(newOrder);
            }
            _orderRepository.Save();
        }

        public void ResetCustomerBase()
        {
            ClearCustomerBase();
            AddSampleCustomers();
        }

        private void ClearCustomerBase()
        {
            var customers = _customerRepository.GetAll();
            foreach (var customer in customers)
            {
                _customerRepository.Remove(customer);
            }
            _customerRepository.Save();
        }

        private void AddSampleCustomers()
        {
            var newCustomers = IOrdersProvider.GetSampleCustomers();

            foreach (var customer in newCustomers)
            {
                _customerRepository.Add(customer);
            }
            _customerRepository.Save();
        }
    }
}