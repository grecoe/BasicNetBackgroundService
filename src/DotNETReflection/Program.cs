using DotNETReflection.Domain;
using DotNETReflection.Implementations;

namespace DotNETReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActionEngine engine = new ActionEngine();

            engine.LoadActions();

            ICustomAction addAction= engine.GetCustomAction(Attributes.ActivityType.Add).FirstOrDefault();
            ICustomAction deleteAction = engine.GetCustomAction(Attributes.ActivityType.Delete).FirstOrDefault();

            addAction.Execute("foo", "bar");
            deleteAction.Execute("my", 1);
        }
    }
}
