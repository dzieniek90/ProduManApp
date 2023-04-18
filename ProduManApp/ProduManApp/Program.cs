using ProduManApp.Data;
using ProduManApp.Entities;
using ProduManApp.Repositories;

var repo = new SqlRepository<Order>(new ProduManAppDbContext());
repo.ItemRemoved += DeletingOrder;
repo.ItemAdded += AddingOrder;

var exit = false;

Console.WriteLine("Witaj w menadżerze zleceń!");
while (true)
{
    Console.WriteLine("\nWybierz operację:");
    Console.WriteLine("1. Dodaj zlecenie");
    Console.WriteLine("2. Wyświetl wszystkie zlecenia");
    Console.WriteLine("3. Usuń zlecenie");
    Console.WriteLine("0. Wyjdz z programu");

    var operation = Console.ReadKey();

    switch (operation.KeyChar)
    {
        case '1':
            AddOrder();
            break;

        case '2':
            DisplayAllOrders();
            break;

        case '3':
            RemoveOrder();
            break;

        case '0':
            exit = true;
            break;

        default:
            Console.WriteLine("\nBłąd wuboru Operacji!");
            break;
    }
    if (exit) break;
}

void RemoveOrder()
{
    while (true)
    {
        var error = "";
        DisplayAllOrders();

        Console.WriteLine("\nPodaj Id zlecenia które chcesz usunąć:");

        var orderId = Console.ReadLine();
        if (int.TryParse(orderId, out int orderIdInt))
        {
            var orderToRemove = repo.GetById(orderIdInt);
            if (orderToRemove != null)
            {
                repo.Remove(orderToRemove);
                repo.Save();
                Console.WriteLine("\n\nPomyślnie usunięto zlecenie.");
                return;
            }
            else
            {
                error = "\nBrak zamówienia o podanym numerze Id.";
            }
        }
        else
        {
            error = "\nPodana wartoś nie jest liczbą!";
        }
        Console.WriteLine(error);
    }
}

void DisplayAllOrders()
{
    var orders = repo.GetAll();
    Console.WriteLine("\n\nLista zamówień:");
    Console.WriteLine("--------------------------------------------------------------------------------------");
    Console.WriteLine($"{"Id",-5} {"Nr. zlecenia",-15} {"Nazwa produktu",-20} {"Ilość",-10}");
    Console.WriteLine("--------------------------------------------------------------------------------------");
    foreach (var order in orders)
    {
        {
            Console.WriteLine(order.ToString());
        }
    }
}

void AddOrder()
{
    Order order = null;
    while (true)
    {
        Console.WriteLine("\n\nWbierz typ zlecenia:");
        Console.WriteLine("1. Produkcyjne");
        Console.WriteLine("2. Serwisowe");
        Console.WriteLine("3. Reklamacyjne");

        var operation = Console.ReadKey();
        switch (operation.KeyChar)
        {
            case '1':
                order = new Order();
                break;

            case '2':
                order = new ServiceOrder();
                break;

            case '3':
                order = new ComplaintOrder();
                break;

            default:
                Console.WriteLine("\n Podano zły numer.");
                break;
        }
        if (order != null) break;
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

    repo.Add(order);
    repo.Save();
    Console.WriteLine("\nPomyślnie dodano zlecenie.");
}

void AddingOrder(object? sender, Order e)
{
    AddLog(CreateLog(e, "Dodanie zlecenia"));
}

void DeletingOrder(object? sender, Order e)
{
    AddLog(CreateLog(e, "Usunięcie zlecenia"));
}

string CreateLog(Order order, string action)
{
    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    return ($"[{timestamp}] - {action} - {order}");
}

void AddLog(string log)
{
    string solutionDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", ".."));
    string fileName = "RepositoryLogs.txt";
    string filePath = Path.Combine(solutionDirectory, fileName);

    using (StreamWriter writer = new StreamWriter(filePath, true))
    {
        writer.WriteLine(log);
    }
}

void NumberCounter()
{
    string num = "1233452498";
    int[] tab = new int[10];
    foreach (char c in num)
    {
        tab[c - '0']++;
    }
    for (int i = 0; i < tab.Length; i++)
    {
        Console.WriteLine($"Liczba {i} występuje {tab[i]} razy");
    }
}