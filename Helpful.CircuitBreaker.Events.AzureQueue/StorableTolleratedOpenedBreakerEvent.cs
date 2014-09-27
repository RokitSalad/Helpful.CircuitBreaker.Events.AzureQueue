namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    public class StorableTolleratedOpenedBreakerEvent : StorableOpenedBreakerEvent
    {
        public short TolleratedOpenEventCount { get; set; }
    }
}