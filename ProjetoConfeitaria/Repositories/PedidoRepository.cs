using Microsoft.EntityFrameworkCore;
using ProjetoConfeitaria.Context;
using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pedido>> BuscarTodos()
    {
        return await _context.Pedidos.Include(p => p.Cliente).Include(p => p.ItensPedido).ThenInclude(i => i.Produto).ToListAsync();
    }

    public async Task<Pedido> BuscarPorId(int id)
    {
        return await _context.Pedidos.Include(p => p.Cliente).Include(p => p.ItensPedido).ThenInclude(i => i.Produto).Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Pedido> Criar(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<Pedido> Atualizar(Pedido pedido)
    {
        _context.Entry(pedido).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return pedido;
    }

    public async Task<Pedido> Deletar(int id)
    {
        var pedido = await BuscarPorId(id);
        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }
}
