using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer.Facade;
using BusinessLayer.Dto;

namespace Tests
{
    [TestClass]
    public class TesteMedicamentoFacade
    {
        MedicamentoFacade facade = new MedicamentoFacade();

        [TestMethod]
        public void TestBuscarPorNome()
        {
            using (MedicamentoFacade facade = new MedicamentoFacade())
            {
                var lista = facade.BuscarMedicamentoPorNome("ACIDO ASCORBICO + PARACETAMOL + CLORIDRATO DE FENILEFRINA");
                Assert.IsTrue(lista != null);
            }
        }

        [TestMethod]
        public void TestListarMedicamentos()
        {
            using (MedicamentoFacade facade = new MedicamentoFacade())
            {
                var lista = facade.ListarMedicamentos();
                Assert.IsTrue(lista != null);
            }
        }

        [TestMethod]
        public void TestSalvarMedicamento()
        {
            using (MedicamentoFacade facade = new MedicamentoFacade())
            {
                MedicamentoDTO medicamento = new MedicamentoDTO();

                medicamento = new MedicamentoDTO
                {
                    Registro = 1,
                    Processo = 1,
                    ClasseTerapeutica = "PRODUTO P.TERAPIA SINTOMATICA DA GRIPE",
                    Nome = "ACIDO ASCORBICO + PARACETAMOL + CLORIDRATO DE FENILEFRINA",
                    Apresentacao = "100 MG + 400 MG + 10 MG COM CT 5 STRIP X 4",
                    Forma = "COMPRIMIDO SIMPLES"
                };

                facade.SalvarMedicamento(medicamento);

                var lista = facade.BuscarMedicamentoPorNome("ACIDO ASCORBICO + PARACETAMOL + CLORIDRATO DE FENILEFRINA");

                Assert.IsTrue(lista != null);
            }
        }
    }
}
