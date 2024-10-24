using Microsoft.EntityFrameworkCore;
using ProjetoConfeitaria.Context;
using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public class PedidoRepository : Repository<Pedido>, IPedidoRepository
{
    public PedidoRepository(AppDbContext context) : base(context) { }

    // Método específico para buscar pedidos por status
    public async Task<IEnumerable<Pedido>> GetPedidosPorStatusAsync(string status)
    {
        return await _dbSet.Where(p => p.Status == status).ToListAsync();
    }
}