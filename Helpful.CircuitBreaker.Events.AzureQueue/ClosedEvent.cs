namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal class ClosedEvent : IClosedEvent
    {
        private readonly IAzureQueue _queue;

        public ClosedEvent(IAzureQueue queue)
        {
            _queue = queue;
        }

        public void RaiseEvent(ICircuitBreakerDefinition breakerDefinition)
        {
            StorableEvent sEvent = StorableEventFactory.BuildEvent<ClosedEvent>(breakerDefinition);
            _queue.Store(sEvent);
        }
    }
}
