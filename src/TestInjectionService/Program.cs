namespace TestInjectionService
{
    using TestInjectionService.Domain;
    using TestInjectionService.Services;
    using TestInjectionService.Domain.Interfaces;

    public class Program
    {
        /// <summary>
        /// Application exposing multiple DI instances, that is, it builds up different data to eventually
        /// pass a list of DI object into the final collection to be processed by the worker service.
        /// </summary>
        public static void Main(string[] args)
        {
 
            var builder = Host.CreateApplicationBuilder(args);

            // Get the configuration for the actions that will be constructed.
            IConfigurationSection? actionConfigSection = builder.Configuration.GetSection("ActionConfigurations");
            if (actionConfigSection == null)
            {
                throw new ArgumentException("No section in configuration called ActionConfiguration");
            }

#pragma warning disable CS8604
            List<IActionConfiguration> configOptions =
                actionConfigSection
                .Get<List<ActionConfiguration>>()
                .Select(x => x as IActionConfiguration)
                .ToList();
#pragma warning restore CS8604

            if (configOptions.Count == 0)
            {
                throw new Exception("Required configurations missing from settings");
            }

            // Add services
            builder.Services.AddHostedService<Worker>();

            //Add the IActionConfigurationsCollection
            builder.Services.AddSingleton<IActionConfigurationsCollection>(new ActionConfigurationCollection(configOptions));
            
            // Add the actions (injected with IActionConfigurationsCollection
            builder.Services.AddSingleton<ICustomAction, AddAction>();
            builder.Services.AddSingleton<ICustomAction, DeleteAction>();

            // Create the ActionEngine Injected with IEnumerable<ICustomAction>
            builder.Services.AddSingleton<IActionEngine, ActionEngine>();

            var host = builder.Build();
            host.Run();
        }
    }
}