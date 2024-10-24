using AutoMapper;
using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        CreateMap<Cliente, ClienteDTO>().ReverseMap();
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
        CreateMap<Pedido, PedidoDTO>().ReverseMap();
        CreateMap<ItemPedido, ItemPedidoDTO>().ReverseMap();
        CreateMap<Admin, AdminDTO>().ReverseMap();
    }
}
