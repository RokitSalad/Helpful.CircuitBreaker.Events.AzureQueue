namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal class UnregisterBreakerEvent : IUnregisterBreakerEvent
    {
        private readonly IAzureQueue _queue;

        public UnregisterBreakerEvent(IAzureQueue queue)
        {
            _queue = queue;
        }

        public void RaiseEvent(ICircuitBreakerDefinition breakerDefinition)
        {
            StorableEvent sEvent = StorableEventFactory.BuildEvent<UnregisterBreakerEvent>(breakerDefinition);
            _queue.Store(sEvent);
        }
    }
}