namespace NETWorkerService.Models
{
    /// <summary>
    /// We can be more specific in what we are after here because it is, afterall
    /// the end of the chain so this component needs all the information to proceed.
    /// </summary>
    internal class CosmosPersistData : PersistDataBase
    {
        private readonly ILogger<CosmosPersistData> _logger;
        private readonly CosmosSettings? _settings;

        public CosmosPersistData(ILogger<CosmosPersistData> _logger, IConfiguration configuration) : base(configuration)
        {
            this._logger = _logger;
            this._settings = configuration.GetSection("CosmosSettings").Get<CosmosSettings>();

            if (_settings == null)
            {
                this._logger.LogError("Really expecting some settings here!");
            }
        }

        /// <summary>
        /// Implement only what we want to implement.....
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void SaveData(string data)
        {
            if (this._logger.IsEnabled(LogLevel.Information))
            {
                this._logger.LogInformation($"Saving data to Cosmos : {_settings.CosmosEndpoint}");
                this._logger.LogInformation($"COSMOS DATA : {data}");
            }
        }
    }
}
