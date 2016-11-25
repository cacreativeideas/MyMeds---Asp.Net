using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    [Table("Medicamentos")]
    internal class Medicamento : Base
    {
        [Required]
        public int NumeroRegistro { get; set; }
        [Required]
        public int NumeroProcess { get; set; }
        [Required]
        public string ClasseTerapeutica { get; set; }
        [Required]
        public string NomeComercial { get; set; }
        [Required]
        public string Apresentacao { get; set; }
        [Required]
        public string FormaTerapeutica { get; set; }

    }
}
