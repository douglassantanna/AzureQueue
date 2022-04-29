using System;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace omie_queue
{
    public class FilaAsync
    {
        public async Task FilaAsyncAwait(string connectionString, string queueName)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            await queueClient.CreateIfNotExistsAsync();

            if (await queueClient.ExistsAsync())
            {
                Console.WriteLine($"Queue '{queueClient.Name}' created");
            }
            else
            {
                Console.WriteLine($"Queue '{queueClient.Name}' exists");
            }

            // Enfileirar mensagem de forma async
            await queueClient.SendMessageAsync("Hello, World");
            Console.WriteLine($"Message added");

            // Receber mensagem de forma async
            QueueMessage[] retrievedMessage = await queueClient.ReceiveMessagesAsync();
            Console.WriteLine($"Retrieved message with content '{retrievedMessage[0].Body}'");

            // Excluir mensagem de forma async
            await queueClient.DeleteMessageAsync(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
            Console.WriteLine($"Deleted message: '{retrievedMessage[0].Body}'");

            // Excluir fila de forma async
            await queueClient.DeleteAsync();
            Console.WriteLine($"Deleted queue: '{queueClient.Name}'");
        }
    }
}