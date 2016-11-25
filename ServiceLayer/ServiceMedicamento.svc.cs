using BusinessLayer.Dto;
using BusinessLayer.Facade;
using BusinessLayer.Facades;
using Microsoft.AspNet.SignalR.Client;
using System.Collections.Generic;

namespace ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicePessoa" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicePessoa.svc or ServicePessoa.svc.cs at the Solution Explorer and start debugging.
    public class ServiceMedicamento : IServiceMedicamento
    {

        private readonly IHubProxy medicamentosHub = null;

        public ServiceMedicamento()
        {
            var conn = new HubConnection("http://localhost:64667/");
            medicamentosHub = conn.CreateHubProxy("MedicamentosHub");
            conn.Start().Wait();
        }

        public MedicamentoDto BuscarPorCodigo(int codigo)
        {
            using (MedicamentoFacade facade = new MedicamentoFacade())
            {
                return facade.BuscarPorCodigo(codigo);
            }
        }

        public List<MedicamentoDto> ListarMedicamentos()
        {
            using (MedicamentoFacade facade = new MedicamentoFacade())
            {
                return facade.ListarMedicamentos();
            }
        }

        public void SalvarMedicamento(MedicamentoDto medicamento)
        {
            using (MedicamentoFacade facade = new MedicamentoFacade())
            {
                facade.SalvarMedicamento(ref medicamento);
                medicamentosHub.Invoke("NotificarAlteracao", medicamento.Codigo, medicamento.Nome, medicamento.Forma, medicamento.Apresentacao);

            }
        }


    }
}
