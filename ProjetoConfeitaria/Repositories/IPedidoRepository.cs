using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public interface IPedidoRepository : IRepository<Pedido>
{
    Task<IEnumerable<Pedido>> GetPedidosPorStatusAsync(string status);
}

