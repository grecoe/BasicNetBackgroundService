namespace TestInjectionService.Domain
{
    using TestInjectionService.Domain.Attributes;
    using TestInjectionService.Domain.Interfaces;

    public class ActionEngine : IActionEngine
    {
        public IDictionary<ActionAttribute, ICustomAction> Actions { get; } = new Dictionary<ActionAttribute, ICustomAction>();
        private List<ICustomAction> customActions;

        public ActionEngine(IEnumerable<ICustomAction> actions)
        {
            this.customActions = actions.ToList();
            this.CollectActions();
        }

        public IEnumerable<ICustomAction> GetCustomAction<T>(ActionType activityType, Type inputType, ILogger<T> logger)
            where T : class
        {
            if( this.Actions.Count == 0)
            {
                this.CollectActions();
            }

            List<ICustomAction> returnList = Actions
                .Where(x => x.Key.Action == activityType && x.Key.ActionInput.IsAssignableFrom(inputType))
                .Select(x => x.Value).ToList();
            
            returnList.ForEach(x => logger.LogInformation($"Returning {x.Name}"));
            return returnList;
        }

        private void CollectActions()
        {
            var actionsList = this.customActions.Select(x => new Dictionary<Type, ICustomAction>()
            {
                { x.GetType(), x }
            });


            foreach (Dictionary<Type, ICustomAction> actionGroups in actionsList)
            {
                foreach (KeyValuePair<Type, ICustomAction> kvpActions in actionGroups)
                {
                    ActionAttribute? actionAttribute = kvpActions.Key.GetCustomAttributes(false)
                        .Where(x => x.GetType().IsAssignableFrom(typeof(ActionAttribute)))
                        .FirstOrDefault() as ActionAttribute;

                    if (actionAttribute != null)
                    {
                        Actions.Add(actionAttribute, kvpActions.Value);
                    }
                }
            }
        }
    }
}
