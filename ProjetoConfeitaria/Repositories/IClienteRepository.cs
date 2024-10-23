using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> BuscarTodos();
    Task<Cliente> BuscarPorId(int id);
    Task<Cliente> Criar(Cliente cliente);
    Task<Cliente> Atualizar(Cliente cliente);
    Task<Cliente> Deletar(int id);
}

