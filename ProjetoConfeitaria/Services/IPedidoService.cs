using ProjetoConfeitaria.DTOs;
using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Services;

public interface IPedidoService : IService<Pedido, PedidoDTO>
{
    Task<IEnumerable<PedidoDTO>> GetPedidosPorStatusAsync(string status);
}
