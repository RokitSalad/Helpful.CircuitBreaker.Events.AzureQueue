namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    public class StorableEvent
    {
        public string Stream { get; set; }
        public string Category { get; set; }
        public object Data { get; set; }
    }
}
