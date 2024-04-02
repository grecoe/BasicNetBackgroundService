namespace TestInjectionService.Domain.Attributes
{
    public enum ActionType
    {
        None,
        Add,
        Delete,
        Update,
        Read
    }

    /// <summary>
    /// Attributes that define an ICustomAction. 
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct,
                           AllowMultiple = false)
    ]
    public class ActionAttribute : System.Attribute
    {
        public ActionType Action { get; set; } = ActionType.None;
        public Type? ActionInput { get; set; }
        public double Version { get; set; } = 0.0;

        public ActionAttribute()
        {
            // Default value.
            Version = 1.0;
            ActionInput = null;
        }
    }
}
