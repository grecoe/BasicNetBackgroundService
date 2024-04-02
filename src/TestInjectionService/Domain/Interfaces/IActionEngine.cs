namespace TestInjectionService.Domain.Interfaces
{
    using TestInjectionService.Domain.Attributes;

    public interface IActionEngine
    {
        public IEnumerable<ICustomAction> GetCustomAction<T>(ActionType activityType, Type inputType, ILogger<T> logger)
            where T : class;
    }
}
