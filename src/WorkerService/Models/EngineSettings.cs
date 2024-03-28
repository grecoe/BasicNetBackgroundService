namespace NETWorkerService.Models
{
    public class EngineSettings
    {
        public int JobSleepTime { get; set; } = 1000;
        public string JobName { get; set; } = string.Empty;
        public string PreferredPersistence { get; set; } = string.Empty;
    }
}
