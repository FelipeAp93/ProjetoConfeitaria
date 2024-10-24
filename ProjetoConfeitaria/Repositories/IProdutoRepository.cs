using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public interface IProdutoRepository : IRepository<Produto>
{
    Task<IEnumerable<Produto>> GetProdutosDisponiveisAsync();
}
