using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProduMan.DataAccess;
using ProduMan.DataAccess.CQRS;
using ProduManApplicationServices.API.Domain;
using ProduManApplicationServices.API.Validators;
using ProduManApplicationServices.Mappings;
using NLog;
using NLog.Web;
using ProduManAPI.Authentication;
using ProduManApplicationServices.Components.OpenWeather;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

// NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(LogLevel.Trace);
    builder.Host.UseNLog();

// Add services to the container.

    builder.Services.AddAuthentication("BasicAuthentication")
        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

    builder.Services.Configure<ApiBehaviorOptions>(options =>
        options.SuppressModelStateInvalidFilter = true);

    builder.Services.AddFluentValidation(cfg =>
        cfg.RegisterValidatorsFromAssemblyContaining<AddProductionBatchRequestValidator>());

    builder.Services.AddAutoMapper(typeof(ProductionBatchesProfile).Assembly);

    builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(typeof(BaseResponse<>).Assembly));

    builder.Services.AddDbContext<ProduManContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProduManDatabaseConnection")));

    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
    builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
    builder.Services.AddTransient<IWeatherConnector, WeatherConnector>();

    builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        //nlog
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}