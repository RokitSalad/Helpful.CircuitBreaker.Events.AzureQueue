using System;

namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    public class StorableOpenedBreakerEvent : StorableEvent
    {
        public BreakerOpenReason Reason { get; set; }
        public Exception Exception { get; set; }
    }
}