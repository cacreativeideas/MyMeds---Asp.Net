using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto
{
    public class ItemTratamentoDto
    {
        public int Codigo { get; set; }
        public string ValorDose { get; set; }
        public string Informacoes { get; set; }
        public string Intervalo { get; set; }
        public string Periodo { get; set; }
    }
}
