using System;
using System.Text;
using Newtonsoft.Json;

namespace Helpful.CircuitBreaker.Events.AzureQueue
{
    internal static class StorableEventExtensions
    {
        public static byte[] AsJsonBytes(this StorableEvent sEvent)
        {
            if (sEvent == null) throw new ArgumentNullException("sEvent");

            var json = JsonConvert.SerializeObject(sEvent);
            var bytes = Encoding.UTF8.GetBytes(json);
            return bytes;
        }
        public static string AsJson(this StorableEvent sEvent)
        {
            if (sEvent == null) throw new ArgumentNullException("sEvent");

            var json = JsonConvert.SerializeObject(sEvent);
            return json;
        }
    }
}
