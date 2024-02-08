namespace NETWorkerService.Models
{
    /// <summary>
    /// We can be more specific in what we are after here because it is, afterall
    /// the end of the chain so this component needs all the information to proceed.
    /// </summary>
    internal class KustoPersistData: PersistDataBase
    {
        private readonly ILogger<KustoPersistData> _logger;
        private readonly KustoSettings? _settings;

        public KustoPersistData(ILogger<KustoPersistData> _logger, IConfiguration configuration) : base(configuration)
        {
            this._logger = _logger;
            this._settings = configuration.GetSection("KustoSettings").Get<KustoSettings>();

            if (this._settings == null)
            {
                this._logger.LogError("Really expecting some settings here!");
            }

            this.Name = this._settings.Name;
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
                this._logger.LogInformation($"Saving data to Kusto : {_settings.KustoEndpoint}");
                this._logger.LogInformation($"KUSTO DATA : {data}");
            }
        }
    }
}
