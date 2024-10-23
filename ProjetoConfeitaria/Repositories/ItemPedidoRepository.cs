using ProjetoConfeitaria.Models;

namespace ProjetoConfeitaria.Repositories;

public class ItemPedidoRepository : IItemPedidoRepository
{
    public Task<ItemPedido> Atualizar(ItemPedido itemPedido)
    {
        throw new NotImplementedException();
    }

    public Task<ItemPedido> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ItemPedido>> BuscarTodos()
    {
        throw new NotImplementedException();
    }

    public Task<ItemPedido> Criar(ItemPedido itemPedido)
    {
        throw new NotImplementedException();
    }

    public Task<ItemPedido> Deletar(int id)
    {
        throw new NotImplementedException();
    }
}
