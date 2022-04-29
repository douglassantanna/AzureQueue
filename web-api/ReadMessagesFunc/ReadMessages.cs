using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ReadMessagesFunc
{
    public class ReadMessages
    {
        [FunctionName("ReadMessages")]
        public void Run([QueueTrigger("messages", Connection = "teste")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
