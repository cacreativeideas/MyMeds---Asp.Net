using System.Threading.Tasks;
using System.Web.Mvc;
using WebLayer.Models;
using WebLayer.ServiceMedicamento;

namespace WebLayer.Controllers
{
    public class MedicamentoController : Controller
    {
        // GET: Pessoa
        public async Task<ActionResult> Index()
        {
            using (ServiceMedicamentoClient cliente = new ServiceMedicamentoClient())
            {

                var lista = await cliente.ListarMedicamentosAsync();
                return View(AutoMapper.Mapper.Map<MedicamentoDetalhe[]>(lista));

            }

        }

        public async Task<ActionResult> Detalhe(int codigo)
        {
            using (ServiceMedicamentoClient cliente = new ServiceMedicamentoClient())
            {
                var medicamento = await cliente.BuscarPorCodigoAsync(codigo);
                return View(AutoMapper.Mapper.Map<MedicamentoDetalhe>(medicamento));
            }
        }

    }
}