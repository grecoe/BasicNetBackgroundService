namespace DotNETReflection.Attributes
{
    public enum ActivityType
    {
        None,
        Add,
        Delete,
        Update,
        Read
    }

    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct,
                           AllowMultiple = false)  
    ]
    public class ActionAttribute : System.Attribute
    {
        public ActivityType Activity { get; set; } = ActivityType.None;
        public double Version { get; set; } = 0.0;

        public ActionAttribute()
        {
            // Default value.
            Version = 1.0;
        }
    }
}
