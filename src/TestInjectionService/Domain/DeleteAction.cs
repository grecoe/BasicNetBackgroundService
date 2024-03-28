namespace TestInjectionService.Domain
{
    using System.Linq;
    using TestInjectionService.Domain.Attributes;
    using TestInjectionService.Domain.Interfaces;

    [Action(Action = ActionType.Delete, Version = 1.1)]
    public class DeleteAction : ActionBase, ICustomAction
    {
        public DeleteAction(IActionConfigurationsCollection configuration)
            : base("Delete Custom Action", configuration.GetActionConfiguration(ActionType.Delete))
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
