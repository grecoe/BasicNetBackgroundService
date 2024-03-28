namespace TestInjectionService.Services
{
    using TestInjectionService.Domain.Interfaces;

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;

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
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ICustomAction? act = this._customActions.GetCustomAction<Worker>(Domain.Attributes.ActionType.Add, _logger).FirstOrDefault();
                if (act != null)
                {
                    await act.Execute<Worker>(_logger, "foo", "bar");
                }

                act = this._customActions.GetCustomAction<Worker>(Domain.Attributes.ActionType.Delete, _logger).FirstOrDefault();
                if (act != null)
                {
                    await act.Execute<Worker>(_logger, "foo", "bar");
                }

                this._applicationLifetime.StopApplication();
                await Task.Delay(100);
            }
        }
    }
}
