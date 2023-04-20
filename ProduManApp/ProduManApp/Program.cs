using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProduManApp;
using ProduManApp.Data;
using ProduManApp.Entities;
using ProduManApp.Repositories;
using ProduManApp.UI;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Order>, ListRepository<Order>>();
services.AddSingleton<IRepository<Customer>, ListRepository<Customer>>();
services.AddSingleton<IUserComunication, UserComunication>();
services.AddDbContext<ProduManAppDbContext>(options => options
    .UseSqlServer("Server=WDZIENKOWSKI\\SQLEXPRESS;DataBase= ProduManApp ; integrated security= true ; Encrypt=False"));


var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();

