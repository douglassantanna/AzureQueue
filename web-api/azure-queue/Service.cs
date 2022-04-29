using System.Text.Json;
using Azure.Storage.Queues;

namespace azure_queue
{
    public class Service : BackgroundService
    {
        private readonly ILogger<WeatherForecast> _logger;
        private readonly QueueClient queueClient;
        public Service(ILogger<WeatherForecast> _logger, QueueClient queueClient)
        {
            this.queueClient = queueClient;
            this._logger = _logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //for each message read, it'll be shown again after 30 seconds.
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Reading from queue");
                var queueMessage = await queueClient.ReceiveMessageAsync();

                if (queueMessage.Value != null)
                {
                    var weatherData = JsonSerializer.Deserialize<WeatherForecast>(queueMessage.Value.MessageText);
                    _logger.LogInformation($"New message read: {weatherData}", weatherData);
                    //do smt to process the data

                    //if the message is not deleted, it'll be available to be read in the next process
                    await queueClient.DeleteMessageAsync(queueMessage.Value.MessageId, queueMessage.Value.PopReceipt);
                }

                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }
    }
}