using BusinessLayer.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceLayer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicePessoa" in both code and config file together.
    [ServiceContract]
    public interface IServicePessoa
    {

        [OperationContract]
        PessoaDto BuscarPorCpf(string cpf);

        [OperationContract]
        PessoaDto BuscarPorCodigo(int codigo);

        [OperationContract]
        List<PessoaDto> ListarPessoas();

        [OperationContract]
        void SalvarPessoa(PessoaDto pessoa);

    }
}
