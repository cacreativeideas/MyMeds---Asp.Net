using BusinessLayer.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicePessoa" in both code and config file together.
    [ServiceContract]
    public interface IServiceMedicamento
    {
        [OperationContract]
        MedicamentoDto BuscarPorCodigo(int codigo);

        [OperationContract]
        List<MedicamentoDto> ListarMedicamentos();

        [OperationContract]
        void SalvarMedicamento(MedicamentoDto pessoa);
    }
}
