using System.Threading.Tasks;
using System.Web.Mvc;
using WebLayer.Models;
using WebLayer.ServicePessoa;

namespace WebLayer.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public async Task<ActionResult> Index()
        {
            using (ServicePessoaClient cliente = new ServicePessoaClient())
            {

                var lista = await cliente.ListarPessoasAsync();
                return View(AutoMapper.Mapper.Map<PessoaDetalhe[]>(lista));

            }

        }

        public async Task<ActionResult> Detalhe(int codigo)
        {
            using (ServicePessoaClient cliente = new ServicePessoaClient())
            {
                var pessoa = await cliente.BuscarPorCodigoAsync(codigo);
                return View(AutoMapper.Mapper.Map<PessoaDetalhe>(pessoa));
            }
        }

    }
}