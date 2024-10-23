using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public interface ICategoriaRepository
{
    Task <IEnumerable<Categoria>> BuscarTodas ();
    Task<IEnumerable<Categoria>> BuscarCategoriasProdutos();
    Task <Categoria> BuscarPorId (int id);
    Task <Categoria> Criar (Categoria categoria);
    Task <Categoria> Atualizar(Categoria categoria);
    Task<Categoria> Deletar(int id);
}
