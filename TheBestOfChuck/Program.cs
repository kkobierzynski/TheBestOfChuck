using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheBestOfChuck.Entities;
using TheBestOfChuck.Middleware;
using TheBestOfChuck.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(builder =>
    {
        builder.UseMiddleware<ExceptionHandlingMiddleware>();
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<IHttpClientService, HttpClientService>();
        services.AddSingleton<ICollectDataService, CollectDataService>();
        services.AddSingleton<ISaveDataService, SaveDataService>();
        services.AddSingleton<IServiceHelper, ServiceHelper>();
        services.AddDbContext<ChuckJokeDbContext>();
        
    })
    .Build();

host.Run();
