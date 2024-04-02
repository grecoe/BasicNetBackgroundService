namespace TestInjectionService.Services
{
    using System.Reflection.Metadata;
    using TestInjectionService.Domain.Interfaces;

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly IConfiguration _configuration;

        IActionEngine _customActions;

        public Worker(
            ILogger<Worker> logger, 
            IConfiguration configuration,
            IHostApplicationLifetime appLifetime, 
            IActionEngine actionEngine) 
        {
            _customActions = actionEngine;
            _logger = logger;
            _applicationLifetime = appLifetime;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000);

                Dictionary<object, Domain.Attributes.ActionType> args = new Dictionary<object, Domain.Attributes.ActionType>()
                {
                    {this._configuration, Domain.Attributes.ActionType.Add},
                    {this._logger , Domain.Attributes.ActionType.Delete }
                };

                /// We have a list of inputs and actions that are going to need to be executed. Based on 
                /// the action type AND the input type, we find the right action(s) to execute.
                foreach (KeyValuePair<object, Domain.Attributes.ActionType> arg in args)
                {
                    IEnumerable<ICustomAction> actions = this._customActions.GetCustomAction<Worker>(
                        arg.Value,
                        arg.Key.GetType(),
                        _logger);

                    foreach(ICustomAction action in actions)
                    {
                        await action.Execute<Worker>(_logger, arg.Key);
                    }
                }


                this._applicationLifetime.StopApplication();
                await Task.Delay(100);
            }
        }
    }
}
