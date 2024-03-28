namespace TestInjectionService.Domain.Interfaces
{
    using TestInjectionService.Domain.Attributes;

    public interface IActionConfiguration
    {
        public ActionType ActionType { get; }
        public string EndPoint { get; set; }
        public string Database { get; set; }
        public string Table { get; set; }
    }
}
