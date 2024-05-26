using AutoMapper;

namespace Clientes.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreacionClienteDTO, Cliente>().ReverseMap();
            CreateMap<MostrarClienteDTO, Cliente>().ReverseMap();
        }
    }
}
