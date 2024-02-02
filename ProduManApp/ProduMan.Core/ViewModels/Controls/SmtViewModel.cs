using ProduMan.DataAccess;
using ProduMan.DataAccess.CQRS.Queries;
using ProduManUI.DataAcces.Models;
using ProduManUI.DataAcces.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using entity = ProduMan.DataAccess.Entities;

namespace ProduManUI.Core.ViewModels;

public class SmtViewModel : BaseViewModel
{
    private ProduManContextFactory _produManContextFactory = new ProduManContextFactory();

    private IEnumerable<Order> _testListApi;
    private List<entity.Order> _testListContext;
    private string _apiTime;
    private string _contextTime;
    private string _searchString;
    private string _customerFilter;
    private List<string> _customersForFilter;
    private int _pageSize;

    public SmtViewModel()
    {
        GetCustomersForFilter();
        CommandsInitialize();
    }

    public IEnumerable<Order> TestListApi { get => _testListApi; set => SetField(ref _testListApi, value); }
    public List<entity.Order> TestListContext { get => _testListContext; set => SetField(ref _testListContext, value); }
    public string ApiTime { get => _apiTime; set => SetField(ref _apiTime, value); }
    public string ContextTime { get => _contextTime; set => SetField(ref _contextTime, value); }
    public string SearchString { get => _searchString; set => SetField(ref _searchString, value); }
    public string CustomerFilter { get => _customerFilter; set => SetField(ref _customerFilter, value); }
    public List<string> CustomersForFilter { get => _customersForFilter; set => SetField(ref _customersForFilter, value); }
    public int PageSize { get => _pageSize; set => SetField(ref _pageSize, value); }

    public RelayCommand LoadOrdersCommand { get; set; }

    private void CommandsInitialize()
    {
        LoadOrdersCommand = new RelayCommand(o => LoadOrders());
    }
    public void LoadOrders()
    {
        Task.WhenAll(GetOrdersFromContext(), GetOrdersFromAPI());
    }

    private async Task GetOrdersFromContext()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        var context = _produManContextFactory.CreateDbContext(null);
        var query = new GetOrdersQuery()
        {
            SearchString = SearchString,
            CustomerName = CustomerFilter,
            PageSize = PageSize
        };    
        TestListContext = await query.Execute(context);

        ContextTime = stopwatch.ElapsedMilliseconds.ToString();
    }

    private async Task GetOrdersFromAPI()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        HttpClient _httpClient = new HttpClient();
        OrdersService _ordersService = new OrdersService(new HttpService(_httpClient));
        TestListApi = (await _ordersService.GetAll(SearchString, CustomerFilter, PageSize.ToString()));
        ApiTime = stopwatch.ElapsedMilliseconds.ToString();
    }



    private void GetCustomersForFilter()
    {
        var context = _produManContextFactory.CreateDbContext(null);

        CustomersForFilter = context.Orders.Select(o => o.Firma).Distinct().ToList();
    }
}