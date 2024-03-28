using TestInjectionService.Domain.Attributes;
using TestInjectionService.Domain.Interfaces;

namespace TestInjectionService.Domain
{
    public class ActionConfiguration : IActionConfiguration
    {
        public ActionType ActionType { get; set; }
        public string EndPoint { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
        public string Table { get; set; } = string.Empty;
    }
}
