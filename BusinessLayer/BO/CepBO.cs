using BusinessLayer.Dao;
using BusinessLayer.Dto;
using DataLayer.Dao;
using DataLayer.ServicoCorreios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BO
{
    internal class CepBO : BaseBO
    {
        private CorreiosDao daoCorreios = null;

        public CepBO(BusinessLayer.Dao.SqlServerDao dao) : base(dao)
        {
            daoCorreios = new CorreiosDao();
        }
        
        public EnderecoDto ConsultarCep(string cep)
        {
            var consulta = daoCorreios.ConsultarCep(cep);
            if (consulta == null)
                throw new System.Exception("CEP " + cep + " não encontrado!");

            return AutoMapper.Mapper.Map<enderecoERP, EnderecoDto>(consulta);
        }
    }
}
