using ProduManApp.Data;
using ProduManApp.Entities;
using ProduManApp.Repositories;

var orderRepository = new SqlRepository<Order>(new ProduManAppDbContext());
AddOrders(orderRepository);
AddServiceOrders(orderRepository);
AddComplaintOrder(orderRepository);
WriteAllToConsole(orderRepository);

void WriteAllToConsole(SqlRepository<Order> orderRepository)
{
    var items = orderRepository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

void AddOrders(IRepository<Order> orderRepository)
{
    orderRepository.Add(new Order { ProductName = "Produkt1" });
    orderRepository.Add(new Order { ProductName = "Produkt2" });
    orderRepository.Save();
}


void AddServiceOrders(IWriteRepository<ServiceOrder> serviceOrderRepository)
{
    serviceOrderRepository.Add(new ServiceOrder { ProductName = "Produkt3" });
    serviceOrderRepository.Add(new ServiceOrder { ProductName = "Produkt4" });
    serviceOrderRepository.Save();
}


void AddComplaintOrder(IWriteRepository<ComplaintOrder> complaintOrderRepository)
{
    complaintOrderRepository.Add(new ComplaintOrder { ProductName = "Produkt5" });
    complaintOrderRepository.Add(new ComplaintOrder { ProductName = "Produkt6" });
    complaintOrderRepository.Save();
}