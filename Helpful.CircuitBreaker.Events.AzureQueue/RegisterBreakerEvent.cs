namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal class RegisterBreakerEvent : IRegisterBreakerEvent
    {
        private readonly IAzureQueue _queue;

        public RegisterBreakerEvent(IAzureQueue queue)
        {
            _queue = queue;
        }

        public void RaiseEvent(ICircuitBreakerDefinition breakerDefinition)
        {
            StorableEvent sEvent = StorableEventFactory.BuildEvent<RegisterBreakerEvent>(breakerDefinition);
            _queue.Store(sEvent);
        }
    }
}