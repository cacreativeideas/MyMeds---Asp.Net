using BusinessLayer.BusinessObject;
using BusinessLayer.Dao;
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
            tratamentoBO = new TratamentoBO(dao);
            itemTratamentoBO = new ItemTratamentoBO(dao);
        }

        public void SalvarTratamento(ref TratamentoDto tratamentoDto)
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
