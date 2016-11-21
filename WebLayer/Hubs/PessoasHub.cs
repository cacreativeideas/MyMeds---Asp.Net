using Microsoft.AspNet.SignalR;

namespace WebLayer.Hubs
{
    public class PessoasHub : Hub
    {
        /// <summary>
        /// Esse método será chamado pelo ServiceLayer e notificará todos 
        /// os clientes conectados no Hub
        /// </summary>
        public void NotificarAlteracao(string codigo, string nome, string cpf, string dataNascimento)
        {
            Clients.All.PessoaAlterada(codigo, nome, cpf, dataNascimento);
        }
    }
}