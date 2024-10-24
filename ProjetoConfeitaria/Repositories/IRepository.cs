namespace ProjetoConfeitaria.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> BuscarTodos();
    Task<T?> BuscarPorId(int id);
    Task Criar(T entity);
    Task Atualizar(T entity);
    Task Deletar(int id);
}
