using System.ComponentModel.DataAnnotations;

namespace WebLayer.Models
{
    public class MedicamentoDetalhe
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