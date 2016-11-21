using System.ComponentModel.DataAnnotations;

namespace WebLayer.Models
{
    public class PessoaDetalhe
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }

        [Display(Name = "DisplayDataNascimento", ResourceType = typeof(App_GlobalResources.Resource))]
        public string DataNascimento { get; set; }

    }
}