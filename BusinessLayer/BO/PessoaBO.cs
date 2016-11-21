using BusinessLayer.Dao;
using BusinessLayer.Dto;
using BusinessLayer.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.BO
{
    internal class PessoaBO : BaseBO
    {

        internal PessoaBO(SqlServerDao dao) : base(dao) { }

        public PessoaDto BuscarPessoaPorCpf(string cpf)
        {
            var pessoa = Dao.Buscar<Pessoa>(p => p.Cpf.Equals(cpf)).FirstOrDefault();
            if (pessoa == null)
                throw new Exception("Pessoa com o CPF " + cpf + " não foi encontrada!");

            return AutoMapper.Mapper.Map<Pessoa, PessoaDto>(pessoa);
        }

        public void Salvar(PessoaDto pessoaDto)
        {
            bool insert = false;
            Pessoa pessoa = Dao.Buscar<Pessoa>(p => p.Cpf.Equals(pessoaDto.Cpf)).FirstOrDefault();
            insert = pessoa == null;

            pessoa = AutoMapper.Mapper.Map(pessoaDto, pessoa);
            if (insert)
                Inserir(pessoa);
            else
                Atualizar(pessoa);
        }

        private void Inserir(Pessoa pessoa)
        {
            //Regras para inserir pessoa                
            Dao.Inserir(pessoa);
        }

        private void Atualizar(Pessoa pessoa)
        {
            //Regras para atualizar pessoa
            Dao.Atualizar(pessoa);
        }

        public List<PessoaDto> ListarPessoas()
        {
            var lista = Dao.ListarTodos<Pessoa>();
            return AutoMapper.Mapper.Map<List<PessoaDto>>(lista);
        }

        public PessoaDto BuscarPorCodigo(int codigo)
        {
            var pessoa = Dao.BuscarPorId<Pessoa>(codigo);
            return AutoMapper.Mapper.Map<PessoaDto>(pessoa);
        }

    }
}
