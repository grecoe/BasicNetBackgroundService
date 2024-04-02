namespace TestInjectionService.Domain
{
    using TestInjectionService.Domain.Attributes;
    using TestInjectionService.Domain.Interfaces;

    /// <summary>
    /// Define the class with an attribute with the expeced input types.
    /// </summary>
    [Action(Action = ActionType.Add, Version = 1.1, ActionInput = typeof(IConfiguration))]
    internal class AddAction : ActionBase
    {
        public AddAction(IActionConfigurationsCollection configuration)
            : base("Add Custom Action", configuration.GetActionConfiguration(ActionType.Add))
        {
        }

        public override async Task Execute<T>(ILogger<T> logger, params object[] parameters)
            where T : class
        {
            logger.LogInformation($"Executing {Name} with {parameters.Count()} parameters");
            logger.LogInformation($"Parameters: {String.Join(", ", parameters.ToList().Select(x => x.ToString()))}");
            await Task.Delay(100);
        }
    }
}
