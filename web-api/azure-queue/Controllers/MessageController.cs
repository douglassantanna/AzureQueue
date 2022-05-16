using System.Text.Json;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;

namespace azure_queue.Controllers;

[ApiController]
[Route("message")]
public class MessageController : ControllerBase
{

    private readonly QueueClient _queueClient;
    public MessageController(QueueClient queueClient)
    {
        _queueClient = queueClient;
    }

    [HttpPost]
    public async Task Post([FromBody] Message msg)
    {
        var message = JsonSerializer.Serialize(msg);

        _queueClient.CreateIfNotExists();

        if (_queueClient.Exists()) //message will be visible after 20 sec and disappear then.
            await _queueClient.SendMessageAsync(message, TimeSpan.FromSeconds(20));
    }
}
