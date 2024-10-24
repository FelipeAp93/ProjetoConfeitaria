namespace ProjetoConfeitaria.Services;

public interface IService<T, TDTO>
{
    Task<IEnumerable<TDTO>> BuscarTodos();
    Task<TDTO?> BuscarPorId(int id);
    Task Criar(TDTO dto);
    Task Atualizar(TDTO dto);
    Task Deletar(int id);
}


