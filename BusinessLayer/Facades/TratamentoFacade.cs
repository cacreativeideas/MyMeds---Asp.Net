using BusinessLayer.BO;
using BusinessLayer.Dao;
using BusinessLayer.Dto;
using BusinessLayer.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Facade
{
    public class TratamentoFacade : BaseFacade
    {
        private TratamentoBO tratamentoBO;
        private ItemTratamentoBO itemTratamentoBO;

        public TratamentoFacade()
        {
            tratamentoBO = new TratamentoBO(Dao);
            itemTratamentoBO = new ItemTratamentoBO(Dao);
        }

        public void SalvarTratamento(ref TratamentoDto dto)
        {
            Log.Info("Salvando tratamento: " + dto.Tratamento);

            //Salva ou atualiza a tratamento
            tratamentoBO.Salvar(dto);

            //Executa as alteracoes no banco de dados
            Dao.SaveChanges();
        }

        public List<TratamentoDto> ListarTratamentos()
        {
            Log.Debug("Listando tratamentos...");
            return tratamentoBO.ListarTratamentos();
        }

        public TratamentoDto BuscarPorCodigo(int codigo)
        {
            return tratamentoBO.BuscarPorCodigo(codigo);
        }
    }
}
