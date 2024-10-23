using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public interface IItemPedidoRepository
{
    Task<IEnumerable<ItemPedido>> BuscarTodos();
    Task<ItemPedido> BuscarPorId(int id);
    Task<ItemPedido> Criar(ItemPedido itemPedido);
    Task<ItemPedido> Atualizar(ItemPedido itemPedido);
    Task<ItemPedido> Deletar(int id);
}

