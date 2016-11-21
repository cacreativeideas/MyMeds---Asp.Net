using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto
{
    public class PessoaDto
    {
        public int Codigo { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
    }
}
