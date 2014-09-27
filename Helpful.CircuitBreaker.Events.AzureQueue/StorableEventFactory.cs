namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal static class StorableEventFactory
    {
        internal static StorableEvent BuildEvent<T>(ICircuitBreakerDefinition definition)
        {
            StorableEvent sEvent = new StorableEvent
            {
                Stream = typeof (T).Name,
                Category = definition.BreakerId,
                Data = definition
            };
            return sEvent;
        }
    }
}
