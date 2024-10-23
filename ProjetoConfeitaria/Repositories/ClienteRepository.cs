using Microsoft.EntityFrameworkCore;
using ProjetoConfeitaria.Context;
using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> BuscarTodos()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente> BuscarPorId(int id)
    {
        return await _context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Cliente> Criar(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> Atualizar(Cliente cliente)
    {
        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> Deletar(int id)
    {
        var cliente = await BuscarPorId(id);
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }
}
