namespace TestInjectionService.Domain
{
    using TestInjectionService.Domain.Attributes;
    using TestInjectionService.Domain.Interfaces;

    public class ActionConfigurationCollection : IActionConfigurationsCollection
    {
        public List<IActionConfiguration> ActionConfigurations { get; set; } = new List<IActionConfiguration>();

        public ActionConfigurationCollection(List<IActionConfiguration> configs)
        {
            ActionConfigurations = configs;
        }

        public IActionConfiguration? GetActionConfiguration(ActionType actionType)
        {
            return ActionConfigurations.Where(x => x.ActionType == actionType)
                .ToList()
                .FirstOrDefault();
        }
    }
}
