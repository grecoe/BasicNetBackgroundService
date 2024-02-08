namespace NETWorkerService.Models
{
    /// <summary>
    /// Class with the same name as the section in the appsettings.json file. This is a handy
    /// place to keep generic information that your application will need but NEVER a secret
    /// of any kind.
    /// </summary>
    internal class KustoSettings
    {
        public string Name { get; set; } = "Kusto";
        public string KustoEndpoint { get; set; } = string.Empty;
        public string KustoDB { get; set; } = string.Empty;
        public string KustoTable { get; set; } = string.Empty;
    }
}
