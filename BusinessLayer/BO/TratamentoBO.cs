using BusinessLayer.Dao;
using BusinessLayer.Dto;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BO
{
    internal class TratamentoBO : BaseBO
    {
        internal TratamentoBO(SqlServerDao dao) : base(dao) { }

        public TratamentoDto BuscarTratamentoPorTitulo(string titulo)
        {
            var tratamento = Dao.Buscar<Tratamento>(t => t.Titulo.Equals(titulo)).FirstOrDefault();
            if (tratamento == null)
                throw new Exception("Tratamento com o titulo " + titulo + " não foi encontrada!");

            return AutoMapper.Mapper.Map<Tratamento, TratamentoDto>(tratamento);
        }

        public void Salvar(TratamentoDto tratamentoDto)
        {
            bool insert = false;
            Tratamento tratamento = Dao.Buscar<Tratamento>(t => t.Id.Equals(tratamentoDto.Codigo)).FirstOrDefault();
            insert = tratamento == null;

            tratamento = AutoMapper.Mapper.Map(tratamentoDto, tratamento);
            if (insert)
                Inserir(tratamento);
            else
                Atualizar(tratamento);
        }

        private void Inserir(Tratamento tratamento)
        {
            //Regras para inserir tratamento                
            Dao.Inserir(tratamento);
        }

        private void Atualizar(Tratamento tratamento)
        {
            //Regras para atualizar tratamento
            Dao.Atualizar(tratamento);
        }

        public List<TratamentoDto> ListarTratamentos()
        {
            var lista = Dao.ListarTodos<Tratamento>();
            return AutoMapper.Mapper.Map<List<TratamentoDto>>(lista);
        }

        public TratamentoDto BuscarPorCodigo(int codigo)
        {
            var tratamento = Dao.BuscarPorId<Tratamento>(codigo);
            return AutoMapper.Mapper.Map<TratamentoDto>(tratamento);
        }
    }
}
