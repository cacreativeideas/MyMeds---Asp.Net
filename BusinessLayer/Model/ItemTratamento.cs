using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    [Table("ItensTratamentos")]
    internal class ItemTratamento : Base
    {
        [Required]
        public string Dosagem { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string IntervaloTempo { get; set; }
        [Required]
        public string PeriodoTempo { get; set; }
        public virtual Tratamento Tratamento { get; set; }
        public virtual Medicamento Medicamento { get; set; }
    }
}
