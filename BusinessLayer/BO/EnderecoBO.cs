using BusinessLayer.Dao;
using BusinessLayer.Dto;
using BusinessLayer.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BO
{
    internal class EnderecoBO : BaseBO
    {
        internal EnderecoBO(SqlServerDao dao) : base(dao) { }

        public void SalvarEndereco(int idPessoa, EnderecoDto endereco)
        {
            var tabela = AutoMapper.Mapper.Map<Endereco>(endereco);
            tabela.PessoaId = idPessoa;
            
            Dao.Inserir(tabela);
        }
    }
}
