namespace ProjetoConfeitaria.Models;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public DateTime DataPedido { get; set; }
    public List<ItemPedido>? ItensPedido { get; set; }
    public string? Status { get; set; }  // Ex: "Em preparo", "Pronto", "Entregue"
}

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



