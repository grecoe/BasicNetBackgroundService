using DotNETReflection.Attributes;
using DotNETReflection.Implementations;

namespace DotNETReflection.Domain
{
    internal class ActionEngine
    {
        public IDictionary<ActionAttribute, ICustomAction> Actions { get; } = new  Dictionary<ActionAttribute, ICustomAction>();

        public ActionEngine()
        {
        }

        public IEnumerable<ICustomAction> GetCustomAction(ActivityType activityType)
        {
            List<ICustomAction>  returnList = Actions.Where(x => x.Key.Activity == activityType).Select(x=> x.Value).ToList();
            returnList.ForEach(x => Console.WriteLine($"Returning {x.Name}"));
            return returnList;
        }

        public void LoadActions()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(ICustomAction).IsAssignableFrom(p) && p.IsClass);

            foreach (var type in types)
            {
                ActionAttribute? actionAttribute = 
                    type.GetCustomAttributes(false)
                    .Where(x => x.GetType().IsAssignableFrom(typeof(ActionAttribute)))
                    .FirstOrDefault() as ActionAttribute;

                // No attribute, no love
                if(actionAttribute != null)
                {
                    var action = (ICustomAction)Activator.CreateInstance(type);
                    Actions.Add(actionAttribute, action);
                }
            }
        }
    }
}
