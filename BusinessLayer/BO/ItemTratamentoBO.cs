using BusinessLayer.Dao;
using BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BO
{
    internal class ItemTratamentoBO : BaseBO
    {
        internal ItemTratamentoBO(SqlServerDao dao) : base(dao) { }

        public ItemTratamentoDto BuscarItemPorTratamento(string titulo)
        {
            //Falta fazer
            return null;
        }
    }
}
