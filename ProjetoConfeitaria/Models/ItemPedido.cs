namespace ProjetoConfeitaria.Models;


public class ItemPedido
{
    public int Id { get; set; }
    public int PedidoId { get; set; }  // Relacionamento com Pedido
    public Pedido? Pedido { get; set; }
    public int ProdutoId { get; set; }  // Relacionamento com Produto
    public Produto? Produto { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
}
