using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    internal class Pessoa : Base
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        public virtual List<Endereco> Enderecos { get; set; }
    }
}
