using AutoMapper;
using ProjetoConfeitaria.DTOs;
using ProjetoConfeitaria.Models;
using ProjetoConfeitaria.Repositories;

namespace ProjetoConfeitaria.Services;

public class PedidoService : Service<Pedido, PedidoDTO>, IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IMapper _mapper;

    public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        : base(pedidoRepository, mapper)
    {
        _pedidoRepository = pedidoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PedidoDTO>> GetPedidosPorStatusAsync(string status)
    {
        var pedidos = await _pedidoRepository.GetPedidosPorStatusAsync(status);
        return _mapper.Map<IEnumerable<PedidoDTO>>(pedidos);
    }
}

