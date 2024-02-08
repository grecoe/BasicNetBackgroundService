namespace NETWorkerService.Models
{
    /// <summary>
    /// Class with the same name as the section in the appsettings.json file. This is a handy
    /// place to keep generic information that your application will need but NEVER a secret
    /// of any kind.
    /// </summary>
    public class CosmosSettings
    {
        public string CosmosEndpoint { get; set; } = string.Empty;
        public string CosmosDB { get; set; } = string.Empty;
        public string CosmosCollection { get; set; } = string.Empty;
    }
}
