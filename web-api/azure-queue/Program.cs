using Azure.Storage.Queues;
using azure_queue;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddHostedService<Service>();
builder.Services.AddAzureClients(builder =>
{
    builder.AddClient<QueueClient, QueueClientOptions>((options, _, _) =>
    {
        options.MessageEncoding = QueueMessageEncoding.Base64;
        var connectionString = "DefaultEndpointsProtocol=https;AccountName=teste;AccountKey=Uj5O3f5tQJEGbW0ZERx+LkCRHRDpY1eK278k5mxFs9TrjrMQFsufHaZ/XbLyF6swaJtPdTmKxHPkVbIdlYoIZQ==;EndpointSuffix=core.windows.net";
        var queueName = "messages";
        return new QueueClient(connectionString, queueName, options);
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
