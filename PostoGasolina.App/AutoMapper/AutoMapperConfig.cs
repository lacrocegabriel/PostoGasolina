using AutoMapper;
using PostoGasolina.App.ViewModels;
using PostoGasolina.Business.Models;

namespace PostoGasolina.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente,ClienteViewModel>().ReverseMap();
            CreateMap<Veiculo,VeiculoViewModel>().ReverseMap();
            //CreateMap<Combustivel,CombustivelViewModel>().ReverseMap();
            CreateMap<Abastecimento,AbastecimentoViewModel>().ReverseMap();

        }
    }
}
