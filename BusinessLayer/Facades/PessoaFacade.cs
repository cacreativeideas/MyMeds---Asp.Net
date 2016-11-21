using BusinessLayer.BO;
using BusinessLayer.Dto;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Facades
{
    public class PessoaFacade : BaseFacade
    {

        private CepBO cepBO;
        private EnderecoBO enderecoBO;
        private PessoaBO pessoaBO;

        public PessoaFacade()
        {
            cepBO = new CepBO(Dao);
            enderecoBO = new EnderecoBO(Dao);
            pessoaBO = new PessoaBO(Dao);
        }

        public void SalvarPessoa(ref PessoaDto dto)
        {
            Log.Info("Salvando pessoa: " + dto.NomeCompleto);

            //Salva ou atualiza a pessoa
            pessoaBO.Salvar(dto);

            //Executa as alteracoes no banco de dados
            Dao.SaveChanges();

            //Localiza a pessoa no banco
            dto = BuscarPorCpf(dto.Cpf);
        }

        public PessoaDto BuscarPorCpf(string cpf)
        {
            Log.Info("Buscando pessoa pelo cpf " + cpf);

            return pessoaBO.BuscarPessoaPorCpf(cpf);
        }

        public void SalvarEndereco(string cpfPessoa, string cep, string numero, string complemento)
        {
            try
            {
                //Obrigatorio existir uma pessoa
                var pessoa = pessoaBO.BuscarPessoaPorCpf(cpfPessoa);

                //Obrigatorio um CEP valido
                var end = cepBO.ConsultarCep(cep);

                //Termina de preencher o endereco
                end.Numero = numero;
                end.Complemento = complemento;

                //Salvar o endereco
                enderecoBO.SalvarEndereco(pessoa.Codigo, end);

                //Executa as alteracoes no banco de dados
                Dao.SaveChanges();
            }
            catch (Exception exc)
            {
                Log.Error("Problema ao salvar endereco: " + exc.Message);
                throw;
            }
        }

        public List<PessoaDto> ListarPessoas()
        {
            Log.Debug("Listando pessoas...");
            return pessoaBO.ListarPessoas();
        }

        public PessoaDto BuscarPorCodigo(int codigo)
        {
            return pessoaBO.BuscarPorCodigo(codigo);
        }

    }
}
