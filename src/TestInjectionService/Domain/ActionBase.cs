namespace TestInjectionService.Domain
{
    using TestInjectionService.Domain.Interfaces;

    public class ActionBase: ICustomAction
    {
        public string Name { get; set; } = string.Empty;
        public IActionConfiguration Configuration { get; private set; }

        public ActionBase(string name, IActionConfiguration? configuration)
        {
            if(configuration == null)
            {
                throw new ArgumentNullException($"Configuration not present for {name}");
            }

            Configuration = configuration;
            Name = name;
        }

        public virtual async Task Execute<T>(ILogger<T> logger, params object[] parameters)
            where T : class
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }
    }
}
