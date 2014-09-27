using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal class AzureQueue : IAzureQueue
    {
        private readonly string _connectionString;
        private readonly string _queueName;
        private CloudQueue _queue;

        private CloudQueue Queue
        {
            get
            {
                if (_queue == null)
                {
                    InitialiseQueue();
                }
                return _queue;
            }
        }

        public AzureQueue(string connectionString, string queueName)
        {
            _connectionString = connectionString;
            _queueName = queueName;
        }

        public void Store(StorableEvent sEvent)
        {
            CloudQueueMessage message = new CloudQueueMessage(sEvent.AsJson());
            Queue.AddMessageAsync(message);
        }

        private void InitialiseQueue()
        {
            CloudStorageAccount account;
            if (!CloudStorageAccount.TryParse(_connectionString, out account))
            {
                throw new ConfigurationErrorsException("Storage account connection string cannot be parsed.");
            }
            CloudQueueClient client = account.CreateCloudQueueClient();

            _queue = client.GetQueueReference(_queueName);
            _queue.CreateIfNotExists();
        }
    }
}
