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
    internal class MedicamentoBO : BaseBO
    {
        internal MedicamentoBO(SqlServerDao dao) : base(dao) { }

        public MedicamentoDto BuscarMedicamentoPorNome(string nome)
        {
            var medicamento = Dao.Buscar<Medicamento>(m => m.NomeComercial.Equals(nome)).FirstOrDefault();
            if (medicamento == null)
                throw new Exception("Medicamento com o nome " + nome + " não foi encontrada!");

            return AutoMapper.Mapper.Map<Medicamento, MedicamentoDto>(medicamento);
        }

        public void Salvar(MedicamentoDto medicamentoDto)
        {
            bool insert = false;
            Medicamento medicamento = Dao.Buscar<Medicamento>(m => m.Codigo.Equals(medicamentoDto.Codigo)).FirstOrDefault();
            insert = medicamento == null;

            medicamento = AutoMapper.Mapper.Map(medicamentoDto, medicamento);
            if (insert)
                Inserir(medicamento);
            else
                Atualizar(medicamento);
        }

        private void Inserir(Medicamento medicamento)
        {
            //Regras para inserir medicamento                
            Dao.Inserir(medicamento);
        }

        private void Atualizar(Medicamento medicamento)
        {
            //Regras para atualizar medicamento
            Dao.Atualizar(medicamento);
        }

        public List<MedicamentoDto> ListarMedicamentos()
        {
            var lista = Dao.ListarTodos<Medicamento>();
            return AutoMapper.Mapper.Map<List<MedicamentoDto>>(lista);
        }

        public MedicamentoDto BuscarPorCodigo(int codigo)
        {
            var medicamento = Dao.BuscarPorId<Medicamento>(codigo);
            return AutoMapper.Mapper.Map<MedicamentoDto>(medicamento);
        }

    }
}
