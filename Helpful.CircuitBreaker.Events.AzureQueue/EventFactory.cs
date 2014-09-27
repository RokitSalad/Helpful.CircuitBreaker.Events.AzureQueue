namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal class EventFactory : IEventFactory
    {
        private readonly IClosedEvent _closedEvent;
        private readonly IOpenedEvent _openedEvent;
        private readonly IRegisterBreakerEvent _registerBreakerEvent;
        private readonly ITryingToCloseEvent _tryingToCloseEvent;
        private readonly IUnregisterBreakerEvent _unregisterBreakerEvent;
        private readonly ITolleratedOpenEvent _tolleratedOpenEvent;

        public EventFactory(IAzureQueue queue)
        {
            _closedEvent = new ClosedEvent(queue);
            _openedEvent = new OpenedEvent(queue);
            _registerBreakerEvent = new RegisterBreakerEvent(queue);
            _tryingToCloseEvent = new TryingToCloseEvent(queue);
            _unregisterBreakerEvent = new UnregisterBreakerEvent(queue);
            _tolleratedOpenEvent = new TolleratedOpenEvent(queue);
        }

        public IClosedEvent GetClosedEvent()
        {
            return _closedEvent;
        }

        public IOpenedEvent GetOpenedEvent()
        {
            return _openedEvent;
        }

        public ITryingToCloseEvent GetTriedToCloseEvent()
        {
            return _tryingToCloseEvent;
        }

        public IUnregisterBreakerEvent GetUnregisterBreakerEvent()
        {
            return _unregisterBreakerEvent;
        }

        public IRegisterBreakerEvent GetRegisterBreakerEvent()
        {
            return _registerBreakerEvent;
        }

        public ITolleratedOpenEvent GetTolleratedOpenEvent()
        {
            return _tolleratedOpenEvent;
        }
    }
}
