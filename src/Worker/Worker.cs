namespace NETWorkerService.Services
{
    using NETWorkerService.Interfaces;

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly List<IPersistData> _persistors;
        private readonly IHostApplicationLifetime _applicationLifetime;

        /// <summary>
        /// With no effort on your part, you get 
        /// 
        /// - logger 
        /// - configuration
        /// - app lifetime
        /// 
        /// objects for free. 
        /// </summary>
        public Worker(
            ILogger<Worker> logger, 
            IConfiguration configuration, 
            IHostApplicationLifetime appLifetime, 
            IEnumerable<IPersistData> persistors)
        {
            this._logger = logger;
            this._applicationLifetime = appLifetime;
            this._configuration = configuration;
            this._persistors = persistors.ToList();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int differentiator = 1;
            while (!stoppingToken.IsCancellationRequested)
            {
                if (this._logger.IsEnabled(LogLevel.Information))
                {
                    this._logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    this._logger.LogInformation($"Worker has: {this._persistors.Count()} persistors associated");
                }

                // Write something out to each data persistor, this may or may not what you want to do.
                this._persistors.ForEach(x=>x.SaveData($"Data {differentiator}"));
                differentiator += 1;

                if(differentiator > 3)
                {
                    if (this._logger.IsEnabled(LogLevel.Information))
                    {
                        this._logger.LogInformation("Worker has run it's course");
                    }
                    // Kill off the application, only one service here so jump.
                    this._applicationLifetime.StopApplication();
                }
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
