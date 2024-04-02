namespace TestInjectionService.Domain
{
    using TestInjectionService.Domain.Interfaces;

    public abstract class ActionBase: ICustomAction
    {
        /// <summary>
        /// Name of the action
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Optiona configuration coming from appsettings.json as long as it 
        /// has the same type. Should not fail if not present. 
        /// </summary>
        public IActionConfiguration? Configuration { get; private set; }

        public ActionBase(string name, IActionConfiguration? configuration)
        {
            Configuration = configuration;
            Name = name;
        }

        /// <summary>
        /// Never allowed to execute. 
        /// </summary>
        public abstract Task Execute<T>(ILogger<T> logger, params object[] parameters)
            where T : class;
    }
}
