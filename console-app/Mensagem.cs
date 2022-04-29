using System;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace omie_queue
{
    public class Mensagem
    {
        public void AdicionarMensagem(string connectionString, string queueName, string message)
        {

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            queueClient.CreateIfNotExists();

            if (queueClient.Exists())
            {
                queueClient.SendMessage(message);
            }

            Console.WriteLine($"Mensagem: {message} adicionada");
        }

        public void EspiarMensagem(string connectionString, string queueName)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            if (queueClient.Exists())
            {
                // Peek at the next message
                PeekedMessage[] peekedMessage = queueClient.PeekMessages();

                // Display the message
                Console.WriteLine($"Mensagen espiada: '{peekedMessage[0].Body}'");
            }
        }

        public void EditarMensagem(string connectionString, string queueName)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            if (queueClient.Exists())
            {
                // Obtem a mensagem da fila
                QueueMessage[] message = queueClient.ReceiveMessages();

                queueClient.UpdateMessage(message[0].MessageId,
                        message[0].PopReceipt,
                        "Updated contents", // novo conteudo da mensagem
                        TimeSpan.FromSeconds(60.0)  // Faz a mensagem aparecer depois de 60 segundos
                    );
            }
        }

        public void ApagarMensagem(string connectionString, string queueName)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            if (queueClient.Exists())
            {
                // obter proxima mensagem
                QueueMessage[] retrievedMessage = queueClient.ReceiveMessages();

                // Process (i.e. print) the message in less than 30 seconds
                Console.WriteLine($"Processando a mensagem: '{retrievedMessage[0].Body}'");

                // Delete the message
                queueClient.DeleteMessage(retrievedMessage[0].MessageId, retrievedMessage[0].PopReceipt);
            }
        }

        public void ApagarMensagem2(string connectionString, string queueName)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            if (queueClient.Exists())
            {
                // Receive and process 20 messages
                QueueMessage[] receivedMessages = queueClient.ReceiveMessages(20, TimeSpan.FromMinutes(1));

                foreach (QueueMessage message in receivedMessages)
                {
                    // Process (i.e. print) the messages in less than 5 minutes
                    Console.WriteLine($"De-queued message: '{message.Body}'");

                    // Delete the message
                    queueClient.DeleteMessage(message.MessageId, message.PopReceipt);
                }
            }
        }

        public void VerificarQuantidadeMsgEmFila(string connectionString, string queueName)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            if (queueClient.Exists())
            {
                QueueProperties properties = queueClient.GetProperties();

                // Retrieve the cached approximate message count.
                int cachedMessagesCount = properties.ApproximateMessagesCount;

                // Display number of messages.
                Console.WriteLine($"Número de mensagens na fila: {cachedMessagesCount}");
            }
        }
    }
}