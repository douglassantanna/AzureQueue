using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace omie_queue
{
    public class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila();
            FilaAsync filaAsync = new FilaAsync();
            Mensagem mensagem = new Mensagem();

            var builder = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config["AzureQueue"];
            var nomeFila = config["QueueName"];
            var mensagemParaAdd = "Mensagem 01";

            // fila.CriarCliente(connectionString, nomeFila);     
            // fila.CriarFila(connectionString, nomeFila);
            // fila.ExcluirFila(connectionString, nomeFila);
            mensagem.AdicionarMensagem(connectionString, nomeFila, mensagemParaAdd);
            // mensagem.EspiarMensagem(connectionString, nomeFila);
            // mensagem.EditarMensagem(connectionString, nomeFila);
            // mensagem.ApagarMensagem(connectionString, nomeFila);
            // mensagem.ApagarMensagem2(connectionString, nomeFila);
            // mensagem.VerificarQuantidadeMsgEmFila(connectionString, nomeFila);


            // filaAsync.FilaAsyncAwait(connectionString, nomeFila);

        }
    }
}
