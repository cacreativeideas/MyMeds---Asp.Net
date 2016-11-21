using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    internal class Endereco : Base
    {
        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string UF { get; set; }

        [Required]
        public virtual Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }

    }
}
