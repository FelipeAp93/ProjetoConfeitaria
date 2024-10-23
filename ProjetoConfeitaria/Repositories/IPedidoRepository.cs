using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public interface IPedidoRepository
{
    Task<IEnumerable<Pedido>> BuscarTodos();
    Task<Pedido> BuscarPorId(int id);
    Task<Pedido> Criar(Pedido pedido);
    Task<Pedido> Atualizar(Pedido pedido);
    Task<Pedido> Deletar(int id);
}

