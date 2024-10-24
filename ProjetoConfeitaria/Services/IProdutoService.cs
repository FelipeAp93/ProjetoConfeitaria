using ProjetoConfeitaria.DTOs;
using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Services;

public interface IProdutoService : IService<Produto, ProdutoDTO>
{
    Task<IEnumerable<ProdutoDTO>> GetProdutosDisponiveisAsync();
}

