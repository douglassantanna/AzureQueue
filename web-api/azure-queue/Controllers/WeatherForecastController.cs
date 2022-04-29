using System.Text.Json;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Mvc;

namespace azure_queue.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly QueueClient _queueClient;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, QueueClient queueClient)
    {
        _logger = logger;
        _queueClient = queueClient;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Message = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
    public async Task Post([FromBody] WeatherForecast msg)
    {
        var message = JsonSerializer.Serialize(msg);

        _queueClient.CreateIfNotExists();

        if (_queueClient.Exists()) //message will be visible after 60 sec and disappear after.
            await _queueClient.SendMessageAsync(message, TimeSpan.FromSeconds(60));
    }
}
