using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto
{
    public class MedicamentoDto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int  Registro { get; set; }
        public int Processo { get; set; }
        public string ClasseTerapeutica { get; set; }
        public string Apresentacao { get; set; }
        public string Forma { get; set; }
    }
}
