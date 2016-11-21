using BusinessLayer.Dto;
using BusinessLayer.Facades;
using Microsoft.AspNet.SignalR.Client;
using System.Collections.Generic;

namespace ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicePessoa" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicePessoa.svc or ServicePessoa.svc.cs at the Solution Explorer and start debugging.
    public class ServicePessoa : IServicePessoa
    {

        private readonly IHubProxy pessoasHub = null;

        public ServicePessoa()
        {
            var conn = new HubConnection("http://localhost:64667/");
            pessoasHub = conn.CreateHubProxy("PessoasHub");
            conn.Start().Wait();
        }

        public PessoaDto BuscarPorCodigo(int codigo)
        {
            using (PessoaFacade facade = new PessoaFacade())
            {
                return facade.BuscarPorCodigo(codigo);
            }
        }

        public PessoaDto BuscarPorCpf(string cpf)
        {
            using (PessoaFacade facade = new PessoaFacade())
            {
                return facade.BuscarPorCpf(cpf);
            }
        }

        public List<PessoaDto> ListarPessoas()
        {
            using (PessoaFacade facade = new PessoaFacade())
            {
                return facade.ListarPessoas();
            }
        }

        public void SalvarPessoa(PessoaDto pessoa)
        {
            using (PessoaFacade facade = new PessoaFacade())
            {
                facade.SalvarPessoa(ref pessoa);
                pessoasHub.Invoke("NotificarAlteracao", pessoa.Codigo, pessoa.NomeCompleto, pessoa.Cpf, pessoa.DataNascimento.ToShortDateString());

            }
        }


    }
}
