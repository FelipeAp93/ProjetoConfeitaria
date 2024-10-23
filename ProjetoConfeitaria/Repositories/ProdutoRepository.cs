using Microsoft.EntityFrameworkCore;
using ProjetoConfeitaria.Context;
using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> BuscarTodos()
    {
        return await _context.Produtos.Include(p => p.Categoria).ToListAsync();
    }

    public async Task<Produto> BuscarPorId(int id)
    {
        return await _context.Produtos.Include(p => p.Categoria).Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Produto> Criar(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> Atualizar(Produto produto)
    {
        _context.Entry(produto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return produto;
    }

    public async Task<Produto> Deletar(int id)
    {
        var produto = await BuscarPorId(id);
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return produto;
    }
}

