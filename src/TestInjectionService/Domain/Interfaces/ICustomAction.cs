namespace TestInjectionService.Domain.Interfaces
{
    public interface ICustomAction
    {
        public string Name { get; }
        public IActionConfiguration Configuration { get; }

        public Task Execute<T>(ILogger<T> logger, params object[] parameters)
            where T : class;
    }
}
