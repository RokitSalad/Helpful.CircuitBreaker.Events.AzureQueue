namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal class TryingToCloseEvent : ITryingToCloseEvent
    {
        private readonly IAzureQueue _queue;

        public TryingToCloseEvent(IAzureQueue queue)
        {
            _queue = queue;
        }

        public void RaiseEvent(ICircuitBreakerDefinition breakerDefinition)
        {
            StorableEvent sEvent = StorableEventFactory.BuildEvent<TryingToCloseEvent>(breakerDefinition);
            _queue.Store(sEvent);
        }
    }
}