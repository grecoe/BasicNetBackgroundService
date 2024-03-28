namespace TestInjectionService.Domain.Interfaces
{
    using TestInjectionService.Domain.Attributes;

    public interface IActionEngine
    {
        public IEnumerable<ICustomAction> GetCustomAction<T>(ActionType activityType, ILogger<T> logger)
            where T : class;
    }
}
