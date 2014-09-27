using System;

namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal class TolleratedOpenEvent : ITolleratedOpenEvent
    {
        private readonly IAzureQueue _queue;

        public TolleratedOpenEvent(IAzureQueue queue)
        {
            _queue = queue;
        }

        public void RaiseEvent(short tolleratedOpenEventCount, ICircuitBreakerDefinition breakerDefinition, BreakerOpenReason reason,
            Exception exception)
        {
            StorableEvent sEvent = StorableEventFactory.BuildEvent<OpenedEvent>(breakerDefinition, reason, exception, tolleratedOpenEventCount);
            _queue.Store(sEvent);
        }
    }
}