using AutoMapper;

namespace Clientes.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreacionClienteDTO, Cliente>().ReverseMap();
            CreateMap<MostrarClienteDTO, Cliente>().ReverseMap();
            CreateMap<CreacionProductoDTO, Producto>().ReverseMap();
            CreateMap<MostrarProductoDTO, Producto>().ReverseMap();
            CreateMap<MostrarPedidoDTO, Pedido>().ReverseMap();
            CreateMap<CrearPedidoDTO, Pedido>().ReverseMap();
            CreateMap<CrearRenglonesPedidoDTO, RenglonesPedidos>().ReverseMap();
            CreateMap<MostrarRenglonesPedidoDTO, RenglonesPedidos>().ReverseMap();
        }
    }
}
