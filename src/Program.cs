namespace NETWorkerService
{
    using NETWorkerService.Interfaces;
    using NETWorkerService.Models;
    using NETWorkerService.Services;

    public class Program
    {
        public static void Main(string[] args)
        {
            // By default, you'll get an IConfiguration based off the appsettings.json
            // and it will gin up ILogger<T> instances wherever you have a constructor
            // that want's one. 

            var builder = Host.CreateApplicationBuilder(args);
            // Add in services
            builder.Services.AddHostedService<Worker>();
            // Add in IPersistData instances
            builder.Services.AddSingleton<IPersistData, CosmosPersistData>();
            builder.Services.AddSingleton<IPersistData, KustoPersistData>();
            
            // Build and run, put a break point in Worker/Worker to see how things 
            // just magically get put together for you. 
            var host = builder.Build();
            host.Run();
        }
    }
}