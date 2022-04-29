using System;
using Azure.Storage.Queues;

namespace omie_queue
{
    public class Fila
    {
        public QueueClient CriarCliente(string connectionString, string nomefila)
        {
            QueueClient queueClient = new QueueClient(connectionString, nomefila);
            Console.WriteLine("Cliente criado com sucesso {0}", queueClient);
            return queueClient;
        }
        public bool CriarFila(string connectionString, string queueName)
        {
            try
            {
                QueueClient queueClient = new QueueClient(connectionString, queueName);

                queueClient.CreateIfNotExists();

                if (queueClient.Exists())
                {
                    Console.WriteLine($"Fila '{queueClient.Name}' criada.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\n\n");
                Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                return false;
            }
        }

        public void ExcluirFila(string connectionString, string queueName)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            if (queueClient.Exists())
            {
                queueClient.Delete();
            }

            Console.WriteLine($"Fila '{queueClient.Name}' excluída.");
        }
    }
}