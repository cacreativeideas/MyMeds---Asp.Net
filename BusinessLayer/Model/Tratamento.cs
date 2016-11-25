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
    [Table("Tratamentos")]
    internal class Tratamento : Base
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public DateTime DataPrescricao { get; set; }
        [Required]
        public string Diagnostico { get; set; }
        public virtual List<ItemTratamento> ItensTratamento { get; set; }
    }
}
