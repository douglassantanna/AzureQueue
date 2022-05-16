using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ReadMessagesFunc
{
    public class ReadMessages
    {
        [FunctionName("ReadMessages")]
        public void Run([QueueTrigger("messages", Connection = "teste")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"A new message has been read by the function: {myQueueItem}");
        }
    }
}
