namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal interface IAzureQueue
    {
        void Store(StorableEvent sEvent);
    }
}