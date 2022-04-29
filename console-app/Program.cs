using System;
using System.Threading.Tasks;

namespace omie_queue
{
    public class Program
    {

        static void Main(string[] args)
        {
            Fila fila = new Fila();
            FilaAsync filaAsync = new FilaAsync();
            Mensagem mensagem = new Mensagem();
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=testedc1994;AccountKey=zAdSF6pKzjIwSNct0dH5YQwmJdyh9P0QpvIk4b21eazB9qEofy82IEkBRRH+6C1dZARrFCLu/P+aTOszXWHdvw==;EndpointSuffix=core.windows.net";
            var nomeFila = "itens";
            var mensagemParaAdd = "Mensagem 03";

            // fila.CriarCliente(connectionString, nomeFila);     
            // fila.CriarFila(connectionString, nomeFila);
            // fila.ExcluirFila(connectionString, nomeFila);
            // mensagem.AdicionarMensagem(connectionString, nomeFila, mensagemParaAdd);
            // mensagem.EspiarMensagem(connectionString, nomeFila);
            // mensagem.EditarMensagem(connectionString, nomeFila);
            // mensagem.ApagarMensagem(connectionString, nomeFila);
            // mensagem.ApagarMensagem2(connectionString, nomeFila);
            // mensagem.VerificarQuantidadeMsgEmFila(connectionString, nomeFila);
            

            // filaAsync.FilaAsyncAwait(connectionString, nomeFila);

        }
    }
}
