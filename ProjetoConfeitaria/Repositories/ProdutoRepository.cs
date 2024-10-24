using Microsoft.EntityFrameworkCore;
using ProjetoConfeitaria.Context;
using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext context) : base(context) { }

    // Método específico para buscar produtos disponíveis
    public async Task<IEnumerable<Produto>> GetProdutosDisponiveisAsync()
    {
        return await _dbSet.Where(p => p.Disponivel).ToListAsync();
    }
}

