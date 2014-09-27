using System;
using System.Security.AccessControl;

namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal static class StorableEventFactory
    {
        internal static StorableEvent BuildEvent<T>(ICircuitBreakerDefinition definition)
        {
            StorableEvent sEvent = new StorableEvent();
            BuildStorableEvent<T>(sEvent, definition);
            return sEvent;
        }

        public static StorableEvent BuildEvent<T>(ICircuitBreakerDefinition definition, BreakerOpenReason reason, Exception exception)
        {
            StorableOpenedBreakerEvent sEvent = new StorableOpenedBreakerEvent();
            BuildStorableEvent<T>(sEvent, definition);
            sEvent.Reason = reason;
            sEvent.Exception = exception;
            return sEvent;
        }

        private static void BuildStorableEvent<T>(StorableEvent sEvent, ICircuitBreakerDefinition definition)
        {
            sEvent.Stream = typeof (T).Name;
            sEvent.Category = definition.BreakerId;
            sEvent.Data = definition;
        }
    }
}
