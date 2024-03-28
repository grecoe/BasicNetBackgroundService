namespace DotNETReflection.Implementations
{
    using DotNETReflection.Attributes;

    [ActionAttribute(Activity = ActivityType.Add, Version = 1.1)]
    internal class AddAction : ICustomAction
    {
        public string Name { get; set; } = string.Empty;

        public AddAction()
        {
            Name = "Add Custom Action";
        }

        public void Execute(params object[] parameters)
        {
            Console.WriteLine($"Executing {this.Name} with {parameters.Count()} parameters");
            if(parameters.Length > 0)
            {
                foreach(var item in parameters)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }


    [ActionAttribute(Activity = ActivityType.Delete, Version = 1.1)]
    internal class DeleteAction : ICustomAction
    {
        public string Name { get; set; } = string.Empty;

        public DeleteAction()
        {
            Name = "Delete Custom Action";
        }

        public void Execute(params object[] parameters)
        {
            Console.WriteLine($"Executing {this.Name} with {parameters.Count()} parameters");
            if (parameters.Length > 0)
            {
                foreach (var item in parameters)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
