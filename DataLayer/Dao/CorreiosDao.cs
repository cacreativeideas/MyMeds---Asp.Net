using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dao
{
    public class CorreiosDao
    {
        public ServicoCorreios.enderecoERP ConsultarCep(string cep)
        {
            using (ServicoCorreios.AtendeClienteClient cli = new ServicoCorreios.AtendeClienteClient())
            {
                return cli.consultaCEP(cep);
            }
        }
    }
}
