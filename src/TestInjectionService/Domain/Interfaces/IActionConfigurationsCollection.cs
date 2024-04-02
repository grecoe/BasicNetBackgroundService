namespace TestInjectionService.Domain.Interfaces
{
    using TestInjectionService.Domain.Attributes;

    /// <summary>
    /// You can pass a specific configuration to a specific action through the app settings.json file
    /// as long as it has the same type as the action itself. 
    /// </summary>
    public interface IActionConfigurationsCollection
    {
        public List<IActionConfiguration> ActionConfigurations { get; }

        public IActionConfiguration? GetActionConfiguration(ActionType actionType);
    }
}
