using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> BuscarTodos();
    Task<Produto> BuscarPorId(int id);
    Task<Produto> Criar(Produto produto);
    Task<Produto> Atualizar(Produto produto);
    Task<Produto> Deletar(int id);
}
