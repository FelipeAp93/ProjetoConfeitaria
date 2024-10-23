using Microsoft.EntityFrameworkCore;
using ProjetoConfeitaria.Context;
using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public class CategoriaRepository : ICategoriaRepository
{ 
    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categoria>> BuscarTodas()
    {
        return await _context.Categorias.ToListAsync();
    }
    public async Task<IEnumerable<Categoria>> BuscarCategoriasProdutos()
    {
        return await _context.Categorias.Include(c=> c.Produtos).ToListAsync();
    }

    public async Task<Categoria> BuscarPorId(int id)
    {
        return await _context.Categorias.Where(c=> c.CategoriaId == id).FirstOrDefaultAsync();
    }

    public async Task<Categoria> Criar(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> Atualizar(Categoria categoria)
    {
        _context.Entry(categoria).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return categoria;
    }
    public async Task<Categoria> Deletar(int id)
    {
        var categoria = await BuscarPorId(id);
        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
        return categoria; 
    }
}
