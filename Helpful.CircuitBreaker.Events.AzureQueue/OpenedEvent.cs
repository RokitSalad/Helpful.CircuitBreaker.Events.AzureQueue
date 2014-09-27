using System;

namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal class OpenedEvent : IOpenedEvent
    {
        private readonly IAzureQueue _queue;

        public OpenedEvent(IAzureQueue queue)
        {
            _queue = queue;
        }

        public void RaiseEvent(ICircuitBreakerDefinition breakerDefinition, BreakerOpenReason reason, Exception exception)
        {
            StorableEvent sEvent = StorableEventFactory.BuildEvent<OpenedEvent>(breakerDefinition, reason, exception);
            _queue.Store(sEvent);
        }
    }
}