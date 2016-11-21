using BusinessLayer.Dto;
using BusinessLayer.Facades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class TestPessoaFacade
    {

        private PessoaFacade facade = new PessoaFacade();

        [TestMethod]
        public void TestSalvarPessoa()
        {

            var nomes = new[] { "Miguel", "Sophia", "Davi", "Alice", "Arthur", "Julia", "Pedro", "Isabella", "Gabriel", "Manuela", "Bernardo", "Laura", "Lucas", "Luiza", "Matheus", "Valentina", "Rafael", "Giovanna", "Heitor", "Maria Eduarda", "Enzo", "Helena", "Guilherme", "Beatriz", "Nicolas", "Maria Luiza", "Lorenzo", "Lara", "Gustavo", "Mariana", "Felipe", "Nicole", "Samuel", "Rafaela", "João Pedro", "Heloísa", "Daniel", "Isadora", "Vitor", "Lívia", "Leonardo", "Maria Clara", "Henrique", "Ana Clara", "Theo", "Lorena", "Murilo", "Gabriela", "Eduardo", "Yasmin", "Pedro Henrique", "Isabelly", "Pietro", "Sarah", "Cauã", "Ana Julia", "Isaac", "Letícia", "Caio", "Ana Luiza", "Vinicius", "Melissa", "Benjamin", "Marina", "João", "Clara", "Lucca", "Cecília", "João Miguel", "Esther", "Bryan", "Emanuelly", "Joaquim", "Rebeca", "João Vitor", "Ana Beatriz", "Thiago", "Lavínia", "Antônio", "Vitória", "Davi Lucas", "Bianca", "Francisco", "Catarina", "Enzo Gabriel", "Larissa", "Bruno", "Maria Fernanda", "Emanuel", "Fernanda", "João Gabriel", "Amanda", "Ian", "Alícia", "Davi Luiz", "Carolina", "Rodrigo", "Agatha", "Otávio", "Gabrielly" };
            var sobrenomes = new[] { "Mello", "Ribeiro", "Silva", "Beltrão", "Barborin", "Rodrigues", "Santos", "Trindade", "Machado", "Venturine", "Tassinari", "Souza", "Nascimento", "Silveira", "Bugmaer", "Garcia", "Moraes", "Pimenta", "Rosa", "Santana", "Carvalho", "Alvez", "Moreira" };

            foreach (var pessoa in nomes)
            {
                string cpf = DateTime.Now.Ticks.ToString();
                cpf = cpf.Substring(cpf.Length - 11, 11);

                //Inserir
                var dto = new PessoaDto
                {
                    Cpf = cpf,
                    DataNascimento = DateTime.Now,
                    NomeCompleto = pessoa + " " + sobrenomes[new Random(DateTime.Now.Millisecond).Next(sobrenomes.Length - 1)]
                };
                facade.SalvarPessoa(ref dto);


            }
        }


    }
}
