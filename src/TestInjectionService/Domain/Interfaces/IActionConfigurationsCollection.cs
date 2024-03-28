namespace TestInjectionService.Domain.Interfaces
{
    using TestInjectionService.Domain.Attributes;

    public interface IActionConfigurationsCollection
    {
        public List<IActionConfiguration> ActionConfigurations { get; }

        public IActionConfiguration? GetActionConfiguration(ActionType actionType);
    }
}
