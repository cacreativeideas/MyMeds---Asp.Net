using Microsoft.AspNet.SignalR;

namespace WebLayer.Hubs
{
    public class MedicamentosHub : Hub
    {
        /// <summary>
        /// Esse método será chamado pelo ServiceLayer e notificará todos 
        /// os clientes conectados no Hub
        /// </summary>
        public void NotificarAlteracao(string codigo, string nome, string forma, string apresentacao)
        {
            Clients.All.MedicamentoAlterado(codigo, nome, forma, apresentacao);
        }
    }
}