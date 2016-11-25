using AutoMapper;
using WebLayer.Models;
using WebLayer.ServiceMedicamento;
using WebLayer.ServicePessoa;

namespace WebLayer.App_Start
{
    public class MapperConfig
    {
        public static void InicializarMapper()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PessoaDto, PessoaDetalhe>()
                    .ForMember(dest => dest.Codigo, opt => opt.MapFrom(source => source.Codigo))
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(source => source.NomeCompleto))
                    .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(source => source.DataNascimento.ToShortDateString()));

                cfg.CreateMap<MedicamentoDto, MedicamentoDetalhe>()
                    .ForMember(dest => dest.Codigo, opt => opt.MapFrom(source => source.Codigo))
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(source => source.Nome))
                    .ForMember(dest => dest.Apresentacao, opt => opt.MapFrom(source => source.Apresentacao))
                    .ForMember(dest => dest.ClasseTerapeutica, opt => opt.MapFrom(source => source.ClasseTerapeutica))
                    .ForMember(dest => dest.Processo, opt => opt.MapFrom(source => source.Processo))
                    .ForMember(dest => dest.Registro, opt => opt.MapFrom(source => source.Registro))
                    .ForMember(dest => dest.Forma, opt => opt.MapFrom(source => source.Forma));


            });
        }
    }
}