using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto
{
    public class TratamentoDto
    {
        public int Codigo { get; set; }
        public string Tratamento { get; set; }
        public DateTime DataPrescricao { get; set; }
        public string DescricaoDiagnostico { get; set; }
    }
}
