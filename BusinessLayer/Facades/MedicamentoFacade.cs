using BusinessLayer.BusinessObject;
using BusinessLayer.Dao;
using BusinessLayer.Dto;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Facade
{
    public class MedicamentoFacade : BaseFacade
    {
        private MedicamentoBO medicamentoBO;

        public MedicamentoFacade()
        {
            medicamentoBO = new MedicamentoBO(dao);
        }

        public MedicamentoDto BuscarMedicamentoPorNome(string nome)
        {
            Log.Info("Buscando medicamento por nome: " + nome);

            return medicamentoBO.BuscarMedicamentoPorNome(nome);
        }

        public void SalvarMedicamento(ref MedicamentoDto medicamentoDto)
        {
            Log.Info("Salvando medicamento: " + dto.Nome);

            //Salva ou atualiza a medicamento
            medicamentoBO.Salvar(dto);

            //Executa as alteracoes no banco de dados
            Dao.SaveChanges();
        }

        public List<MedicamentoDto> ListarMedicamentos()
        {
            Log.Debug("Listando medicamentos...");
            return medicamentoBO.ListarMedicamentos();
        }

        public MedicamentoDto BuscarPorCodigo(int codigo)
        {
            Log.Info("Buscando medicamento por codigo: " + codigo);

            return medicamentoBO.BuscarPorCodigo(codigo);
        }
    }
}
