using AutoMapper;
using BusinessLayer.Dao;
using BusinessLayer.Dto;
using BusinessLayer.Model;
using DataLayer.ServicoCorreios;
using log4net;
using log4net.Config;
using System;
using System.IO;

namespace BusinessLayer.Facades
{
    public abstract class BaseFacade : IDisposable
    {
        internal SqlServerDao Dao { get; set; }

        //Usado para logar informacoes de falha da aplicacao
        protected static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static BaseFacade()
        {
            #region Log4Net

            XmlConfigurator.Configure(new FileInfo("Log.config"));

            #endregion

            #region  Inicializar automapper

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Pessoa, PessoaDto>()
                    .ForMember(dest => dest.Codigo, opt => opt.MapFrom(source => source.Id))
                    .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(source => source.Nome + " " + source.Sobrenome))
                    .ForMember(dest => dest.Idade, opt => opt.MapFrom(source => (DateTime.Now - source.DataNascimento).TotalDays / 365));

                cfg.CreateMap<PessoaDto, Pessoa>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(source => source.NomeCompleto.Split(' ')[0]))
                    .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(source => source.NomeCompleto.Remove(0, source.NomeCompleto.Contains(" ") ? source.NomeCompleto.IndexOf(' ')+1 : source.NomeCompleto.Length)));

                cfg.CreateMap<Endereco, EnderecoDto>();

                cfg.CreateMap<EnderecoDto, Endereco>();

                cfg.CreateMap<enderecoERP, EnderecoDto>()
                    .ForMember(dest => dest.Cep, opt => opt.MapFrom(source => source.cep))
                    .ForMember(dest => dest.Cidade, opt => opt.MapFrom(source => source.cidade))
                    .ForMember(dest => dest.UF, opt => opt.MapFrom(source => source.uf))
                    .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(source => source.end));

                cfg.CreateMap<Medicamento, MedicamentoDto>()
                    .ForMember(dest => dest.Codigo, opt => opt.MapFrom(source => source.Id))
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(source => source.NomeComercial ))
                    .ForMember(dest => dest.Apresentacao, opt => opt.MapFrom(source => source.Apresentacao))
                    .ForMember(dest => dest.ClasseTerapeutica, opt => opt.MapFrom(source => source.ClasseTerapeutica))
                    .ForMember(dest => dest.Processo, opt => opt.MapFrom(source => source.NumeroProcess))
                    .ForMember(dest => dest.Registro, opt => opt.MapFrom(source => source.NumeroRegistro))
                    .ForMember(dest => dest.Forma, opt => opt.MapFrom(source => source.FormaTerapeutica));

                cfg.CreateMap<MedicamentoDto, Medicamento>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Codigo))
                    .ForMember(dest => dest.NomeComercial, opt => opt.MapFrom(source => source.Nome))
                    .ForMember(dest => dest.Apresentacao, opt => opt.MapFrom(source => source.Apresentacao))
                    .ForMember(dest => dest.ClasseTerapeutica, opt => opt.MapFrom(source => source.ClasseTerapeutica))
                    .ForMember(dest => dest.NumeroProcess, opt => opt.MapFrom(source => source.Processo))
                    .ForMember(dest => dest.NumeroRegistro, opt => opt.MapFrom(source => source.Registro))
                    .ForMember(dest => dest.FormaTerapeutica, opt => opt.MapFrom(source => source.Forma));

                cfg.CreateMap<Tratamento, TratamentoDto>()
                    .ForMember(dest => dest.Codigo, opt => opt.MapFrom(source => source.Id))
                    .ForMember(dest => dest.Tratamento, opt => opt.MapFrom(source => source.Titulo))
                    .ForMember(dest => dest.DescricaoDiagnostico, opt => opt.MapFrom(source => source.Diagnostico))
                    .ForMember(dest => dest.DataPrescricao, opt => opt.MapFrom(source => source.DataPrescricao));

                cfg.CreateMap<TratamentoDto, Tratamento>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Codigo))
                    .ForMember(dest => dest.Titulo, opt => opt.MapFrom(source => source.Tratamento))
                    .ForMember(dest => dest.Diagnostico, opt => opt.MapFrom(source => source.DescricaoDiagnostico))
                    .ForMember(dest => dest.DataPrescricao, opt => opt.MapFrom(source => source.DataPrescricao));

                cfg.CreateMap<ItemTratamento, ItemTratamentoDto>()
                    .ForMember(dest => dest.Codigo, opt => opt.MapFrom(source => source.Id))
                    .ForMember(dest => dest.Informacoes, opt => opt.MapFrom(source => source.Tratamento))
                    .ForMember(dest => dest.Intervalo, opt => opt.MapFrom(source => source.IntervaloTempo))
                    .ForMember(dest => dest.Periodo, opt => opt.MapFrom(source => source.PeriodoTempo))
                    .ForMember(dest => dest.ValorDose, opt => opt.MapFrom(source => source.Dosagem));

                cfg.CreateMap<ItemTratamentoDto, ItemTratamento>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Codigo))
                    .ForMember(dest => dest.Tratamento, opt => opt.MapFrom(source => source.Informacoes))
                    .ForMember(dest => dest.IntervaloTempo, opt => opt.MapFrom(source => source.Intervalo))
                    .ForMember(dest => dest.PeriodoTempo, opt => opt.MapFrom(source => source.Periodo))
                    .ForMember(dest => dest.Dosagem, opt => opt.MapFrom(source => source.ValorDose));

            });

            #endregion
        }

        public BaseFacade()
        {
            Dao = new SqlServerDao();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (Dao != null) Dao.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PessoaFacade() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
